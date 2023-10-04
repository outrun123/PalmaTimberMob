namespace PalmaTimberMob.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int UserAccessId { get; set; }
        public int Group { get; set; }
        public int TypeId { get; set; }

    }
}
