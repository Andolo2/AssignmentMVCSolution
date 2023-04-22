using AssignmentMVC.Models.Entities;
using AssignmentMVC.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC.ViewModels.LoginViewModel
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "You must provide a firstname")]
        public string FirstName { get; set; } = null!;



        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "You must provide a Lastname")]
        public string LastName { get; set; } = null!;


        [Display(Name = "Streetname")]
        [Required(ErrorMessage = "You must provide a Streetname")]
        public string StreetName { get; set; } = null!;


        [Display(Name = "Postalcode")]
        [Required(ErrorMessage = "You must provide a PostalCode")]
        public string PostalCode { get; set; } = null!;


        [Display(Name = "City")]
        [Required(ErrorMessage = "You must provide a City")]
        public string City { get; set; } = null!;


        [Display(Name = "Mobile")]
        public string? Mobile { get; set; }


        [Display(Name = "Company")]
        public string? Company { get; set; } = null!;


        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must provide an Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"/^\S+@\S+\.\S+$/", ErrorMessage = "Email is not valid")]
        public string Email { get; set; } = null!;


        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must provide a Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password is not secure, try again")]
        public string Password { get; set; } = null!;


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You must conform passowrd")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; } = null!;


        [Display(Name = "Upload Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }


        [Display(Name = "I Accept terms and Agreements")]
        [Required(ErrorMessage = "You must agree to the terms...")]
        public bool TermsAndAgreement { get; set; } = false;



        public static implicit operator AppUser(UserRegisterViewModel userRegisterViewModel)
        {
            return new AppUser
            {
                UserName = userRegisterViewModel.Email,
                FirstName = userRegisterViewModel.FirstName,
                LastName = userRegisterViewModel.LastName,
                Email = userRegisterViewModel.Email,
                PhoneNumber = userRegisterViewModel.Mobile,
                CompanyName = userRegisterViewModel.Company,

            };
        }

        public static implicit operator AdressEntity(UserRegisterViewModel userRegisterViewModel)
        {
            return new AdressEntity
            {
                StreetName = userRegisterViewModel.StreetName,
                PostalCode = userRegisterViewModel.PostalCode,
                City = userRegisterViewModel.City
            };
        }

    }
}
