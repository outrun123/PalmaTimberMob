using Microsoft.AspNetCore.Components.WebAssembly.Http;
using PalmaTimberMob.Models;
using RESTFulSense.WebAssembly.Clients;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PalmaTimberMob.Brokers
{
    public class ApiBroker : IApiBroker
    {
        private readonly HttpClient client;
        private readonly IRESTFulApiFactoryClient apiClientPalma;
        private string baseUrl;
        public ApiBroker(IConfiguration configuration)
        {
            this.client = new();
            this.baseUrl = configuration["ApiUrl"];
            this.client.BaseAddress = new Uri(baseUrl);
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{configuration["ApiUsername"]}:{configuration["ApiPassword"]}"));
            // Set the Authorization header with the basic authorization credentials
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            apiClientPalma = new RESTFulApiFactoryClient(client);        
        }

        public async Task<List<Docket>> GetDocketsAsync()
        {
            string url = $"docket/dockets.json";
            List<Docket> dockets = new();
            // var message = await this.client.GetAsync(url);

            dockets = await this.apiClientPalma.GetContentAsync<List<Docket>>(url);
            return dockets;
        }

        public async Task<List<Felling>> GetFellingsAsync()
        {
            string url = $"felling/get_forwarder_fellings.json";
            List<Felling> fellings = new();
            // var message = await this.client.GetAsync(url);

            fellings = await this.apiClientPalma.GetContentAsync<List<Felling>>(url);
            return fellings;
        }

        public async Task<List<Enterprise>> GetEnterprisesAsync()
        {
            string url = $"classifier/enterprises.json";
            List<Enterprise> enterprises = new();

           // var message = await this.client.GetAsync(url);

          
           enterprises = await this.apiClientPalma.GetContentAsync<List<Enterprise>>(url);

            // Display the list of enterprises
            foreach (Enterprise enterprise in enterprises)
            {
                // Console.WriteLine($"Name: {enterprise.Name}, ID: {enterprise.Id}");
            }
       
            return enterprises;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            string url = $"classifier/login.json";
            try
            {

                FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
                {
                 new KeyValuePair<string, string>("username", email),
                 new KeyValuePair<string, string>("password", password)
            });

                HttpResponseMessage response = await this.client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<User> users = JsonSerializer.Deserialize<List<User>>(responseBody);
                User user = null;
                if (users.Count > 0)
                {
                    user = users.First();
                }
                return user;
            }
            catch (Exception ex)
            {
                return null; 
            }
        }
    }
}
