namespace EFCore.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public ICollection<User>? Users { get; set; }
    }
}
