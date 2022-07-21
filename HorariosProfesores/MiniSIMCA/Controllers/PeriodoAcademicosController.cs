using DataAccess.Data.Entities;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MiniSIMCA.Controllers
{
    public class PeriodoAcademicosController : Controller
    {
        private readonly IPeriodoAcademicoService _periodoAcademicoService;

        public PeriodoAcademicosController(IPeriodoAcademicoService periodoAcademicoService)
        {
            _periodoAcademicoService = periodoAcademicoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _periodoAcademicoService.GetAllPeriodosAcamedicosAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(PeriodoAcademico model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model == null)
                    {
                        return NotFound();
                    }

                    await _periodoAcademicoService.CreatePeriodoAcamedicoAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"Ha ocurrido un error: {e.Message}");
                }
            }
            return View(model);
        }
    }
}
