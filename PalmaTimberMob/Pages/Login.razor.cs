using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using PalmaTimberMob.Brokers;
using SqliteWasmHelper;

namespace PalmaTimberMob.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        protected IApiBroker ApiBroker { get; set; } = null!;

        [Inject]
        protected ISqliteWasmDbContextFactory<SqliteBroker> sqliteBroker { get; set; }

        [Inject]
        protected IToastService ToastService { get; set; } = null!;

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public async Task LoginUser()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                var user = await ApiBroker.LoginAsync(Email, Password);
                if (user != null)
                {
                    var broker = await sqliteBroker.CreateDbContextAsync();
                    broker.LoggedInUser.Add(user);
                    await broker.SaveChangesAsync();

                    NavigationManager.NavigateTo("/", true);
                }
                else
                {
                    ToastService.ShowError("Nav atrasts lietotājs ar šādu epastu un paroli!");
                }
            } 
            else
            {
                ToastService.ShowError("Ievadiet epastu/paroli!");
            }
        }
    }
}
