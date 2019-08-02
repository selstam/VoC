namespace Selstam.VoC.Services.VoC.Interfaces
{
    using Selstam.VoC.Services.VoC.Dtos;
    using Selstam.VoC.VoCObjects;

    public interface IVoCService
    {
        /// <summary>
        /// Gets all trips from thew car's logbook
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Trips GetTrips(BaseServiceDto dto);

        /// <summary>
        /// Gets all car's attributes and returns in raw, serialized and dictionary format.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        GetAttributesResultDto GetAttributes(BaseServiceDto dto);

        /// <summary>
        /// Gets your cars status.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        GetStatusResultDto GetStatus(BaseServiceDto dto);

        /// <summary>
        /// Gets car's last reported position.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        GetPositionResultDto GetPosition(BaseServiceDto dto);

        /// <summary>
        /// Locks your car.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        LockResultDto SetLockState(LockDto dto);
    }
}