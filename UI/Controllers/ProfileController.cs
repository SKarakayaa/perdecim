using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Profile;

namespace UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
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
    }
}