using System.ComponentModel.DataAnnotations;
using loppinja.Models.ViewModels.Partial;

namespace loppinja.Models.ViewModels.ActionViewModels.Account
{
    public class LoginViewModel: ActionBaseViewModel
    {

        public LoginViewModel()
        {

        }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}