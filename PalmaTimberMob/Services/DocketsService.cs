using PalmaTimberMob.Brokers;
using PalmaTimberMob.Models;
using SqliteWasmHelper;

namespace PalmaTimberMob.Services
{
    public class DocketsService : IDocketsService
    {
        private readonly ISqliteWasmDbContextFactory<SqliteBroker> sqliteBroker;

        public DocketsService(ISqliteWasmDbContextFactory<SqliteBroker> sqliteBroker)
        {
            this.sqliteBroker = sqliteBroker;
        }

        public async Task<List<Docket>> GetDocketsAsync()
        {
            using var broker = await this.sqliteBroker.CreateDbContextAsync();
            Random rnd = new Random();
            if (broker.Dockets.Any())
            {
                
                broker.Dockets.Add(new Docket { Number = rnd.Next().ToString(), Notes="Next docket" });
            } 
            else
            {
                broker.Dockets.Add(new Docket { Number = rnd.Next().ToString(), Notes = "First docket" });
            }

            await broker.SaveChangesAsync();
            return broker.Dockets.ToList();
        }
    }
}
