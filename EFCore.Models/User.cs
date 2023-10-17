namespace EFCore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public DateTimeOffset RegistrationDate { get; set; } //DateTimeOffset - Guarda a data, horario e fuso horario
        public Contact? Contact { get; set; }
        public ICollection<DeliveryAddress>? DeliveryAddress { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}
