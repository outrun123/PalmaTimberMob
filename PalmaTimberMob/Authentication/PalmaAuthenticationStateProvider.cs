using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PalmaTimberMob.Brokers;
using PalmaTimberMob.Models;
using SqliteWasmHelper;
using System.Security.Claims;

namespace PalmaTimberMob.Authentication
{
    public class PalmaAuthenticationStateProvider : AuthenticationStateProvider
    {
        protected ISqliteWasmDbContextFactory<SqliteBroker> sqliteBroker { get; set; }
        public PalmaAuthenticationStateProvider(ISqliteWasmDbContextFactory<SqliteBroker> sqliteBroker)
        {
            this.sqliteBroker = sqliteBroker;
        }

        public void StateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync()); 
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            using var broker = await this.sqliteBroker.CreateDbContextAsync();
            User CurrentUser = broker.LoggedInUser.FirstOrDefault();

            if (CurrentUser == null)
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
            else
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, CurrentUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, CurrentUser.FullName),
                    new Claim(ClaimTypes.Email, CurrentUser.Email)
                }, "apiauth_type");

                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
           
        }
    }
}
