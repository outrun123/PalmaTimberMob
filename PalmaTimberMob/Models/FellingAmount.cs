namespace PalmaTimberMob.Models
{
    public class FellingAmount
    {
        public int FellingId { get; set; }
        public string PlaceNumber { get; set; }
        public decimal PreparedQuantityM3 { get; set; }
        public decimal ForwardedQuantityM3 { get; set; }
    }
}
