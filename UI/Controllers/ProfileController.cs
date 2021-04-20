using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}