using System.ComponentModel.DataAnnotations;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Models.ViewModels.ActionViewModels.Account
{
    public class RegisterViewModel: ActionBaseViewModel
    {

        public RegisterViewModel()
        {
        }


        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Password Again")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password and ConfirmPassword should be same string.")]
        public string ConfirmPassword { get; set; }
    }
}