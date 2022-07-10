using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MiniSIMCA.Controllers
{
    public class ProgramasController : Controller
    {
        private readonly IProgramaService _service;

        public ProgramasController(IProgramaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProgramas());
        }

    }
}
