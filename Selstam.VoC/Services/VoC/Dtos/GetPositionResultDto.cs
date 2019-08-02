namespace Selstam.VoC.Services.VoC.Dtos
{
    using Selstam.VoC.VoCObjects;

    public class GetPositionResultDto
    {
        public string RawResponse { get; set; }

        public CarPosition Position { get; set; }
    }
}