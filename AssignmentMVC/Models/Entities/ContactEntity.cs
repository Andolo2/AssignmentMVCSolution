namespace AssignmentMVC.Models.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string? Company { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
