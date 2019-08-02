// ---------------------------------------------------------------------
// <copyright file="ServiceResponse.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using Newtonsoft.Json;

namespace Selstam.VoC.VoCObjects
{
    using System;

    public class ServiceResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusTimestamp")]
        public string StatusTimestamp { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("failureReason")]
        public object FailureReason { get; set; }

        [JsonProperty("service")]
        public Uri Service { get; set; }

        [JsonProperty("vehicleId")]
        public string VehicleId { get; set; }

        [JsonProperty("customerServiceId")]
        public string CustomerServiceId { get; set; }
    }
}