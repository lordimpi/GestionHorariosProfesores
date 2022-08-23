using Microsoft.AspNetCore.Mvc;

namespace MiniSIMCA.Controllers
{
    public class AmbienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
