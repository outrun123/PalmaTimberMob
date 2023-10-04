using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using PalmaTimberMob;
using PalmaTimberMob.Authentication;
using PalmaTimberMob.Brokers;
using PalmaTimberMob.Services;
using SqliteWasmHelper;
using Syncfusion.Blazor;

namespace PalmaTimberMob
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IDocketsService, DocketsService>();
            builder.Services.AddScoped<IApiBroker, ApiBroker>();
            builder.Services.AddSqliteWasmDbContextFactory<SqliteBroker>(opts =>
                opts.UseSqlite("Data Source=palmamob3.sqlite3"));

            builder.Services.AddScoped<AuthenticationStateProvider, PalmaAuthenticationStateProvider>();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddBlazoredToast();
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}