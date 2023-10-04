using PalmaTimberMob.Models;

namespace PalmaTimberMob.Brokers
{
    public interface IApiBroker
    {
        Task<List<Docket>> GetDocketsAsync();
        Task<List<Enterprise>> GetEnterprisesAsync();
        Task<List<Felling>> GetFellingsAsync();
        Task<User> LoginAsync(string email, string password);
    }
}
