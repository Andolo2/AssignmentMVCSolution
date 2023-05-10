using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModels.ContactViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^(\d{10})?$", ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; }

        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Add a valid Email")]

        public string Email { get; set; } = null!;

        
        public string? Company { get; set; }

        public string Comment { get; set; } = null!;

        public bool SaveDetails { get; set; }
    }
}
