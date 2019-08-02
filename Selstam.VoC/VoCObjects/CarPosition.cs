// ---------------------------------------------------------------------
// <copyright file="CarPosition.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using Newtonsoft.Json;

namespace Selstam.VoC.VoCObjects
{
    public class CarPosition
    {
        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("calculatedPosition")]
        public Position CalculatedPosition { get; set; }
    }

    public class Position
    {
        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("speed")]
        public object Speed { get; set; }

        [JsonProperty("heading")]
        public object Heading { get; set; }
    }
}