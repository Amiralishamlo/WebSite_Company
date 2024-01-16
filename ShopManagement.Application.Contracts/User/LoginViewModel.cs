using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد نمایید")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا پسورد خود را وارد نمایید")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool IsPersistent { get; set; } = true;

        public string ReturnUrl { get; set; } = "/";
    }
}
