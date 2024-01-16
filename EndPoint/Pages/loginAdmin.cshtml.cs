using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.User;

namespace EndPoint.Pages
{
    public class loginAdminModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public loginAdminModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public LoginViewModel loginView;
        public void OnGet()
        {
        }
        public IActionResult OnPost(LoginViewModel model) 
        {
            var user = _userManager.FindByNameAsync(model.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return Page();
            }
            _signInManager.SignOutAsync();
            var result = _signInManager.PasswordSignInAsync(user, model.Password
                , model.IsPersistent, true).Result;

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }

            return Page();

        }
    }
}
