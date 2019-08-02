using System.Threading.Tasks;

namespace Selstam.VoC.Services.VoCApiClient
{
    public interface IVoCApiClientService
    {
        Task<T> MakeCallAsync<T>(ApiClientDto dto);
        Task<string> MakeCallAsync(ApiClientDto dto);
    }
}