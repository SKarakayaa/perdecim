using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(IAuthService authService, SignInManager<AppUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            if (!ModelState.IsValid)
                return View(register);

            var result = await _authService.Register(register);
            
            if (!result.Succeeded)
                result.Errors.ToList().ForEach(x => ModelState.AddModelError(x.Code, x.Description));
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid)
                return View(login);

            DataResult<AppUser> userIsExist = await _authService.UserIsExist(login.UserName);
            if (userIsExist.IsSuccess)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(userIsExist.Data, login.Password, login.Persistent, login.Lock);
                if (result.Succeeded)
                {
                    await _authService.ResetFailedCount(userIsExist.Data);
                    
                    if (string.IsNullOrEmpty(TempData["returnUrl"]?.ToString()))
                        return RedirectToAction("Index", "Home");
                    return Redirect(TempData["returnUrl"].ToString());
                }
                else
                {
                    Result failedLogin = await _authService.FailedLogin(userIsExist.Data);
                    if (!failedLogin.IsSuccess)
                        ModelState.AddModelError("Locked", failedLogin.Message);
                    else
                    {
                        if (result.IsLockedOut)
                            ModelState.AddModelError("Locked", "Art arda 5 başarısız giriş yaptığınız için hesabınız 30 dakika askıya alınmıştır !");
                        else
                            ModelState.AddModelError("UserNotFound2", "E-posta veya Şifre Yanlış");
                    }

                }
            }
            else
                ModelState.AddModelError("UserNotFound", userIsExist.Message);
            return View(login);
        }
    }
}