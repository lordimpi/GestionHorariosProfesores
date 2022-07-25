using DataAccess.Data;
using DataAccess.Data.Entities;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSIMCA.Helpers;
using MiniSIMCA.Models;
using Vereyon.Web;
using static MiniSIMCA.Helpers.ModalHelper;

namespace MiniSIMCA.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PeriodoAcademicosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPeriodoAcademicoService _periodoAcademicoService;
        private readonly ICombosHelper _combosHelper;
        private readonly IFlashMessage _flashMessage;

        public PeriodoAcademicosController(ApplicationDbContext context, IPeriodoAcademicoService periodoAcademicoService, ICombosHelper combosHelper, IFlashMessage flashMessage)
        {
            _context = context;
            _periodoAcademicoService = periodoAcademicoService;
            _combosHelper = combosHelper;
            _flashMessage = flashMessage;
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
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un programa con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                    return View(model);
                }
            }
            model.Programas = await _combosHelper.GetComboProgramasAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PeriodoAcademico periodoAcademico = await _periodoAcademicoService.GetPeriodoAcamedicoByIdAsync(id);
            if (periodoAcademico == null)
            {
                return NotFound();
            }
            return View(periodoAcademico);
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddPrograma(int id)
        {
            PeriodoAcademico periodoAcademico = await _context.PeriodoAcademicos
                .Include(pa => pa.PeriodoAcademicoProgramas)
                .ThenInclude(pap => pap.Programa)
                .FirstOrDefaultAsync(pa => pa.Periodo_Id == id);
            if (periodoAcademico == null)
            {
                return NotFound();
            }

            List<Programa> programas = periodoAcademico.PeriodoAcademicoProgramas.Select(p => new Programa
            {
                Programa_Id = p.Programa.Programa_Id,
                Programa_Nombre = p.Programa.Programa_Nombre,
            }).ToList();

            AddPeriodoAcademicoViewModel model = new()
            {
                PeriodoId = periodoAcademico.Periodo_Id,
                Programas = await _combosHelper.GetComboProgramasAsync(programas),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPrograma(AddPeriodoAcademicoViewModel model)
        {
            PeriodoAcademico periodoAcademico = await _context.PeriodoAcademicos
                 .Include(pa => pa.PeriodoAcademicoProgramas)
                 .ThenInclude(pap => pap.Programa)
                 .FirstOrDefaultAsync(pa => pa.Periodo_Id == model.PeriodoId);

            if (ModelState.IsValid)
            {
                PeriodoAcademicoPrograma periodoAcademicoPrograma = new()
                {
                    Programa = await _context.Programas.FindAsync(model.ProgramaId),
                    PeriodoAcademico = periodoAcademico,
                };

                try
                {
                    _context.Add(periodoAcademicoPrograma);
                    await _context.SaveChangesAsync();
                    _flashMessage.Confirmation("Programa agregado.");
                    return Json(new
                    {
                        isValid = true,
                        html = ModalHelper.RenderRazorViewToString(this, "Details", _context.PeriodoAcademicos
                                        .Include(p => p.PeriodoAcademicoProgramas)
                                        .ThenInclude(pap => pap.Programa)
                                        .FirstOrDefaultAsync(p => p.Periodo_Id == model.ProgramaId))
                    });
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                }
            }

            List<Programa> programas = periodoAcademico.PeriodoAcademicoProgramas.Select(pap => new Programa
            {
                Programa_Id = pap.Programa.Programa_Id,
                Programa_Nombre = pap.Programa.Programa_Nombre
            }).ToList();

            model.Programas = await _combosHelper.GetComboProgramasAsync(programas);
            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddPrograma", model) });
        }

        public async Task<IActionResult> DeletePrograma(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PeriodoAcademicoPrograma periodoAcademicoPrograma = await _context.PeriodoAcademicoProgramas
                .Include(pap => pap.PeriodoAcademico)
                .FirstOrDefaultAsync(pa => pa.PeriodoAcademicoId == id);
            if (periodoAcademicoPrograma == null)
            {
                return NotFound();
            }

            _context.PeriodoAcademicoProgramas.Remove(periodoAcademicoPrograma);
            await _context.SaveChangesAsync();
            _flashMessage.Info("Registro borrado.");
            return RedirectToAction(nameof(Details), new { Id = periodoAcademicoPrograma.PeriodoAcademico.Periodo_Id });
        }

        [NoDirectAccess]
        public async Task<IActionResult> Delete(int id)
        {

            PeriodoAcademico periodoAcademico = await _context.PeriodoAcademicos
                .Include(pa => pa.PeriodoAcademicoProgramas)
                .FirstOrDefaultAsync(pa => pa.Periodo_Id == id);
            if (periodoAcademico == null)
            {
                return NotFound();
            }

            _context.PeriodoAcademicos.Remove(periodoAcademico);
            await _context.SaveChangesAsync();
            _flashMessage.Info("Registro borrado.");
            return RedirectToAction(nameof(Index));
        }
    }
}
