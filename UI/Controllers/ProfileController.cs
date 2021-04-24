using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Profile;

namespace UI.Controllers
{
    [Authorize]

    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByIdAsync(User.FindFirst("UserId").Value);
            ProfileIndexViewModel model = new ProfileIndexViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.Name + " " + user.Surname,
                IsEmailConfirm = user.EmailConfirmed,
                Phone = user.PhoneNumber
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            if (!ModelState.IsValid)
                return View(nameof(ChangePassword), changePassword);

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            bool isValidateOldPassword = await _userManager.CheckPasswordAsync(user, changePassword.CurrentPassword);
            bool isConfirmedNewPassword = changePassword.NewPassword == changePassword.NewPasswordConfirm;

            if (isValidateOldPassword && isConfirmedNewPassword)
            {
                IdentityResult result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);

                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                    return View(nameof(ChangePassword), changePassword);
                }

                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, true);
                TempData["ToastMessage"] = "Şifre Başarıyla Değiştirildi !";
                return RedirectToAction(nameof(ChangePassword), "Profile");
            }
            ModelState.AddModelError("ConfirmPassword", "Hatalı Giriş Yaptınız !");
            return View(nameof(ChangePassword), changePassword);
        }
    }
}