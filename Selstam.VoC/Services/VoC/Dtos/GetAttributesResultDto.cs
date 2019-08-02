namespace Selstam.VoC.Services.VoC.Dtos
{
    using System.Collections.Generic;

    using Selstam.VoC.VoCObjects;

    public class GetAttributesResultDto
    {
        public string RawResponse { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public CarAttributes Attributes { get; set; }
    }
}