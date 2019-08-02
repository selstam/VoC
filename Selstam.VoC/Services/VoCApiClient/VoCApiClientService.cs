// ---------------------------------------------------------------------
// <copyright file="VoCApiClientService.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Selstam.VoC.Services.VoCApiClient
{
    using System;
    using System.Net.Http.Headers;

    public class VoCApiClientService : IVoCApiClientService
    {
        private const string DeviceId = "Device";
        private const string OriginatorType = "App";
        private const string OsType = "Android";
        private const string OsVersion = "22";

        public async Task<T> MakeCallAsync<T>(ApiClientDto dto)
        {
            var apiResponse = await MakeCallAsync(dto);
            var data = JsonConvert.DeserializeObject<T>(apiResponse);
            return data;
        }

        public async Task<string> MakeCallAsync(ApiClientDto dto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-device-id", DeviceId);
                client.DefaultRequestHeaders.Add("x-originator-type", OriginatorType);
                client.DefaultRequestHeaders.Add("x-os-type", OsType);
                client.DefaultRequestHeaders.Add("x-os-version", OsVersion);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var authData = Encoding.Default.GetBytes($"{dto.Username}:{dto.Password}");
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(authData));

                switch (dto.RequestMethod)
                {
                    case RequestMethod.GET:
                        using (var response = await client.GetAsync(dto.Uri))
                        {
                            response.EnsureSuccessStatusCode();
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            return apiResponse;
                        }
                    case RequestMethod.POST:
                        using (var response = await client.PostAsync(dto.Uri, new StringContent(dto.BodyContent, Encoding.UTF8, dto.MediaType)))
                        {
                            response.EnsureSuccessStatusCode();
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            return apiResponse;
                        }
                    default:
                        throw new Exception($"Request method {dto.RequestMethod} not supported.");
                }
               
            }
        }
    }

    public class ApiClientDto
    {
        public Uri Uri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RequestMethod RequestMethod { get; set; } = RequestMethod.GET;
        public string BodyContent { get; set; } = string.Empty;
        public string MediaType { get; set; } = "application/json";
    }

    public enum RequestMethod
    {
        GET,
        POST
    }
}