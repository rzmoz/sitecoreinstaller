using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SitecoreInstaller.Host.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _log;

        public HomeController(ILogger<HomeController> log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            _log.LogInformation($"Logging is up and running!!!");
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
