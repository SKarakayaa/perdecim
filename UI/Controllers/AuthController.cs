using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTO.Auth;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
    }
}