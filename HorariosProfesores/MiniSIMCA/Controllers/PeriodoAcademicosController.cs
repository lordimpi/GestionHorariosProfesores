using DataAccess.Data;
using DataAccess.Data.Entities;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSIMCA.Helpers;
using MiniSIMCA.Models;

namespace MiniSIMCA.Controllers
{
    public class PeriodoAcademicosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPeriodoAcademicoService _periodoAcademicoService;
        private readonly ICombosHelper _combosHelper;

        public PeriodoAcademicosController(ApplicationDbContext context, IPeriodoAcademicoService periodoAcademicoService, ICombosHelper combosHelper)
        {
            _context = context;
            _periodoAcademicoService = periodoAcademicoService;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _periodoAcademicoService.GetAllPeriodosAcamedicosAsync());
        }

        public async Task<IActionResult> Create()
        {
            CreatePeriodoAcademicoViewModel model = new()
            {
                Programas = await _combosHelper.GetComboProgramasAsync()
            };
            return View(model);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(CreatePeriodoAcademicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model == null)
                    {
                        return NotFound();
                    }

                    PeriodoAcademico periodo = new()
                    {
                        Periodo_Nombre = model.Periodo_Nombre,
                        IsActive = model.IsActive,
                        Periodo_FechaFin = model.Periodo_FechaFin,
                        Periodo_FechaInicio = model.Periodo_FechaInicio,
                        PeriodoAcademicoProgramas = new List<PeriodoAcademicoPrograma>()
                    {
                        new PeriodoAcademicoPrograma()
                        {
                            Programa = await _context.Programas.FindAsync(model.Programa_Id)
                        }
                    }
                    };
                    await _periodoAcademicoService.CreatePeriodoAcamedicoAsync(periodo);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"Ha ocurrido un error: {e.Message}");
                }
            }
            model.Programas = await _combosHelper.GetComboProgramasAsync();
            return View(model);
        }


    }
}
