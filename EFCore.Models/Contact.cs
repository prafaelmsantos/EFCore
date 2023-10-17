namespace EFCore.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Phone { get; set; }

        public User? User { get; set; }
    }
}
