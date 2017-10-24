using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SitecoreInstaller.Host.Controllers
{
    public class LobbyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
