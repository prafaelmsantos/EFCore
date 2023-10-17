namespace EFCore.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Number { get; set; }
        public User? User { get; set; }
    }
}
