using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PalmaTimberMob.Authentication;
using PalmaTimberMob.Brokers;
using SqliteWasmHelper;
using System.Security.Claims;
using System.Text;

namespace PalmaTimberMob.Shared
{
    public partial class MainLayout 
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; } = null!;
        
        [Inject]
        protected ISqliteWasmDbContextFactory<SqliteBroker> SQLiteBroker { get; set; } = null!;

        bool drawerOpen = true;

        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        public async Task LogoutUser()
        {            
            using var broker = await this.SQLiteBroker.CreateDbContextAsync();
            broker.LoggedInUser.RemoveRange(broker.LoggedInUser);
            await broker.SaveChangesAsync();

            var authState = await AuthState;
            // await AuthenticationState.StateChanged();
            this.NavigationManager.NavigateTo("/Login", true);
        }

        public void LoginUser()
        {
            this.NavigationManager.NavigateTo("/Login");
        }

        void DrawerToggle()
        {
            drawerOpen = !drawerOpen;
        }

    }
}
