namespace Selstam.VoC.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using McMaster.Extensions.CommandLineUtils;

    using Newtonsoft.Json;

    using Selstam.VoC.Helpers;
    using Selstam.VoC.Services.VoC.Dtos;
    using Selstam.VoC.Services.VoC.Interfaces;

    [Command(Description = "Gets car's technical attributes.")]
    public class AttributesCommand : VoCCommandBase
    {
        private readonly IVoCService _vocService;

        public AttributesCommand(IVoCService vocService)
        {
            _vocService = vocService;
        }

        [Argument(0, Description = "Filter attributes separated by space.")]
        public string[] Filter { get; }

        private VolvoOnCallService Parent { get; set; }

        protected override int OnExecute(CommandLineApplication app)
        {
            var attributesResponse = _vocService.GetAttributes(new AttributesDto
            {
                Username = Parent.Username,
                Password = Parent.Password,
                Server = Parent.Server,
                Vin = Parent.Vin
            });

            if (Filter != null && Filter.Any())
            {
                foreach (var attribute in Filter)
                {
                    if (!attributesResponse.Data.ContainsKey(attribute))
                        continue;

                    Console.WriteLine(!Parent.OmitKey
                        ? $"{attribute}={attributesResponse.Data[attribute]}"
                        : $"{attributesResponse.Data[attribute]}");
                }

                return 0;
            }

            if (Parent.BeautifyJson)
            {
                Console.WriteLine(JsonConvert.SerializeObject(attributesResponse, Formatting.Indented));
            }
            else if (Parent.Table)
            {
                var dt = new DataTable("Attributes");
                dt.Columns.Add("Vehicle type", typeof(string));
                dt.Columns.Add("Typecode", typeof(string));
                dt.Columns.Add("ModelYear", typeof(long));
                dt.Columns.Add("Fuel", typeof(string));
                dt.Columns.Add("Plate number", typeof(string));
                dt.Columns.Add("VIN", typeof(string));
                dt.Columns.Add("Tank (l)", typeof(string));
                dt.Rows.Add(
                    attributesResponse.Attributes.VehicleType,
                    attributesResponse.Attributes.VehicleTypeCode,
                    attributesResponse.Attributes.ModelYear,
                    attributesResponse.Attributes.FuelType,
                    attributesResponse.Attributes.RegistrationNumber,
                    attributesResponse.Attributes.Vin,
                    attributesResponse.Attributes.FuelTankVolume);
                dt.Print();
            }

            return 0;
        }

        public override List<string> CreateArgs()
        {
            var args = Parent.CreateArgs();
            args.Add("attributes");

            return args;
        }
    }
}