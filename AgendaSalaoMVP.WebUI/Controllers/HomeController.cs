using Microsoft.AspNetCore.Mvc;

namespace AgendaSalaoMVP.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
