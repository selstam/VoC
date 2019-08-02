namespace Selstam.VoC.Services.VoC.Dtos
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using Selstam.VoC.VoCObjects;

    public class GetStatusResultDto
    {
        [JsonIgnore]
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

        public Status Status { get; set; }

        public CarAttributes Attributes { get; set; }

        public CarPosition Position { get; set; }
    }
}