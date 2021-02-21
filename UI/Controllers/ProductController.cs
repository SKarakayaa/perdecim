using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.BaseUrl = "https://" + HttpContext.Request.Host.ToString();
            return View();
        }
    }
}