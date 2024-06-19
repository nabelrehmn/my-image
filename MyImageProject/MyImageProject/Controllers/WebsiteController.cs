using Microsoft.AspNetCore.Mvc;

namespace MyImageProject.Controllers
{
    public class WebsiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
