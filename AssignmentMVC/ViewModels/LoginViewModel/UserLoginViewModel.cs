using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModels.LoginViewModel
{
    public class UserLoginViewModel
    {



       

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must provide an Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must provide a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Keep me logged in")]
        public bool RememberMe { get; set; } = false;

        public string ReturnUrl { get; set; } = "/";



    }
}
