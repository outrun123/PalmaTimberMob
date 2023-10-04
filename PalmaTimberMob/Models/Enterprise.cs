namespace PalmaTimberMob.Models
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public int HorizonSystemId { get; set; }
        public bool Seller { get; set; }
        public bool Buyer { get; set; }
    }
}
