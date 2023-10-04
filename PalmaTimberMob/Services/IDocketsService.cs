using PalmaTimberMob.Models;

namespace PalmaTimberMob.Services
{
    public interface IDocketsService
    {
        Task<List<Docket>> GetDocketsAsync();
    }
}
