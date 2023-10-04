using Microsoft.AspNetCore.Components;
using PalmaTimberMob.Brokers;
using PalmaTimberMob.Models;

namespace PalmaTimberMob.Pages
{
    public partial class CirsmasPage : ComponentBase
    {
        [Inject]
        protected IApiBroker ApiBroker { get; set; } = null!;
        public List<Felling> Fellings { get; set; } = new List<Felling>();

        protected override async Task OnInitializedAsync()
        {
            Fellings = await ApiBroker.GetFellingsAsync();
            Console.WriteLine($"Fellings: {Fellings.Count}");
            
        }
    }
}
