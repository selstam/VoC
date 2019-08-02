namespace Selstam.VoC.Services.VoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Newtonsoft.Json;

    using Selstam.VoC.Helpers;
    using Selstam.VoC.Services.VoC.Dtos;
    using Selstam.VoC.Services.VoC.Interfaces;
    using Selstam.VoC.Services.VoCApiClient;
    using Selstam.VoC.VoCObjects;

    public class VoCService : IVoCService
    {
        private readonly IVoCApiClientService _apiClientService;

        public VoCService(IVoCApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        public Trips GetTrips(BaseServiceDto dto)
        {
            var apiDto = new ApiClientDto
            {
                Username = dto.Username,
                Password = dto.Password,
                Uri = UriHelper.Create(dto.Server, dto.Vin, "trips")
            };

            var response = _apiClientService.MakeCallAsync<Trips>(apiDto).Result;

            return response;
        }

        public GetAttributesResultDto GetAttributes(BaseServiceDto dto)
        {
            var apiDto = new ApiClientDto
            {
                Username = dto.Username,
                Password = dto.Password,
                Uri = UriHelper.Create(dto.Server, dto.Vin, "attributes")
            };

            var ret = new GetAttributesResultDto
            {
                RawResponse = _apiClientService.MakeCallAsync(apiDto).Result
            };

            ret.Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(ret.RawResponse);
            ret.Attributes = JsonConvert.DeserializeObject<CarAttributes>(ret.RawResponse);

            return ret;
        }

        public GetPositionResultDto GetPosition(BaseServiceDto dto)
        {
            var statusDto = new ApiClientDto
            {
                Username = dto.Username,
                Password = dto.Password,
                Uri = UriHelper.Create(dto.Server, dto.Vin, "position")
            };
            var ret = new GetPositionResultDto
            {
                RawResponse = _apiClientService.MakeCallAsync(statusDto).Result
            };
            ret.Position = JsonConvert.DeserializeObject<CarPosition>(ret.RawResponse);

            return ret;
        }

        public GetStatusResultDto GetStatus(BaseServiceDto dto)
        {
            var ret = new GetStatusResultDto();

            var statusDto = new ApiClientDto
            {
                Username = dto.Username,
                Password = dto.Password,
                Uri = UriHelper.Create(dto.Server, dto.Vin, "status")
            };
            var rawStatus = _apiClientService.MakeCallAsync(statusDto).Result;

            ret.Status = JsonConvert.DeserializeObject<Status>(rawStatus);
            ret.Data.AddSerializedDictionary(rawStatus);

            var attributes = GetAttributes(dto);
            ret.Attributes = attributes.Attributes;
            ret.Data.AddSerializedDictionary(attributes.RawResponse);

            var position = GetPosition(dto);
            ret.Position = position.Position;
            ret.Data.AddSerializedDictionary(position.RawResponse);

            return ret;
        }

        public LockResultDto SetLockState(LockDto dto)
        {
            var status = GetStatus(dto);

            if (dto.NewState == LockState.Locked && !status.Attributes.LockSupported ||
                dto.NewState == LockState.Unlocked && !status.Attributes.UnlockSupported)
                throw new UnsupportedActionException(dto.Vin, dto.NewState.ToString());

            var position = GetPosition(dto);

            var apiAction = dto.NewState == LockState.Unlocked ? "unlock" : "lock";

            var lockDto = new ApiClientDto
            {
                Username = dto.Username,
                Password = dto.Password,
                Uri = UriHelper.Create(dto.Server, dto.Vin, apiAction),
                RequestMethod = RequestMethod.POST,
                BodyContent = "{\n\t\"clientAccuracy\":0,\n\t\"clientLatitude\":" + position.Position.Position.Latitude + ",\n\t\"clientLongitude\":" + position.Position.Position.Longitude + " \n}"
            };

            var response = _apiClientService.MakeCallAsync<ServiceResponse>(lockDto).Result;

            var requestTime = DateTimeOffset.UtcNow;
            var ret = new LockResultDto
            {
                Status = -1
            };

            while (ret.Status < 0)
            {
                if ((DateTimeOffset.UtcNow - requestTime).TotalSeconds >= dto.Timeout)
                {
                    ret.Status = 1;
                    break;
                }

                var confirmationDto = new ApiClientDto
                {
                    Username = dto.Username,
                    Password = dto.Password,
                    Uri = response.Service,
                };

                ret.Response = _apiClientService.MakeCallAsync<ServiceResponse>(confirmationDto).Result;

                switch (ret.Response.Status.ToUpperInvariant())
                {
                    case "SUCCESSFUL":
                        ret.Status = 0;
                        break;
                    case "FAILED":
                        ret.Status = 1;
                        break;
                    default:
                        Thread.Sleep(10000);
                        break;
                }
            }

            return ret;
        }
    }
}