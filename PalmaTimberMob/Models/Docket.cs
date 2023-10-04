namespace PalmaTimberMob.Models
{
    public class Docket
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Notes { get; set; }
        public string NotesTransport { get; set; }
        public decimal RequestedQuantity { get; set; }
        public decimal LoadedQuantity { get; set; }
        public int KilometersWithoutCargo { get; set; }
        public int KilometersWithCargo { get; set; }
    }
}
