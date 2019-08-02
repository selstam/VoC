namespace Selstam.VoC.Services.VoC.Dtos
{
    public class LockDto : BaseServiceDto
    {
        public int Timeout { get; set; } = 140;

        public LockState NewState { get; set; }
    }

    public enum LockState
    {
        Locked,
        Unlocked
    }
}