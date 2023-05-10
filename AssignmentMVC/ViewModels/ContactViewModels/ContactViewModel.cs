using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModels.ContactViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; } = null!;

        //[RegularExpression(@"^(\d{10})?$", ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; } 

        [Required(ErrorMessage = "Please enter your email address")]
        ////[EmailAddress(ErrorMessage = "Please enter a valid email address")]
        //[RegularExpression(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your company name")]
        public string? Company { get; set; }

        public string Comment { get; set; } = null!;

        public bool SaveDetails { get; set; }
    }
}
