using Microsoft.AspNetCore.Mvc;

namespace SitecoreInstaller.Host.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Forms()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View();
        }
    }
}
