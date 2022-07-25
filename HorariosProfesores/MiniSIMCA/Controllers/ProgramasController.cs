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
    public class ProgramasController : Controller
    {
        private readonly IProgramaService _programaService;
        private readonly ICompetenciaService _competenciaService;
        private readonly IFlashMessage _flashMessage;
        private readonly ApplicationDbContext _context;
        private readonly ICombosHelper _combosHelper;

        public ProgramasController(IProgramaService service, ICompetenciaService competenciaService,
            IFlashMessage flashMessage, ApplicationDbContext context, ICombosHelper combosHelper)
        {
            _programaService = service;
            _competenciaService = competenciaService;
            _flashMessage = flashMessage;
            _context = context;
            _combosHelper = combosHelper;
        }

        #region Programas
        public async Task<IActionResult> Index()
        {
            return View(await _programaService.GetProgramas());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programa Programa = await _programaService.GetProgramaById(id);
            if (Programa == null)
            {
                return NotFound();
            }

            return View(Programa);
        }

        [NoDirectAccess]
        public async Task<IActionResult> Delete(int? id)
        {
            Programa programa = await _programaService.GetProgramaById(id);
            try
            {
                await _programaService.DeletePrograma(id);
                _flashMessage.Info("Registro desactivado.");
            }
            catch
            {
                _flashMessage.Danger("No se puede borrar el Programa porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Index));
        }

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Programa());
            }
            else
            {
                Programa Programa = await _programaService.GetProgramaById(id);
                if (Programa == null)
                {
                    return NotFound();
                }

                return View(Programa);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Programa programa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) //Insert
                    {
                        await _programaService.CreatePrograma(programa);
                        _flashMessage.Info("Registro creado.");
                    }
                    else //Update
                    {
                        programa.Programa_Id = id;
                        await _programaService.ModifyPrograma(programa);
                        _flashMessage.Info("Registro actualizado.");
                    }
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe un programa con el mismo nombre.");
                    }
                    else
                    {
                        _flashMessage.Danger(dbUpdateException.InnerException.Message);
                    }
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProgramas", _programaService.GetProgramas()) });
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                    return View(programa);
                }
                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProgramas", _programaService.GetProgramas()) });
            }
            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddOrEdit", programa) });
        }

        #endregion

        #region Competencias
        [NoDirectAccess]
        public async Task<IActionResult> AddCompetencia(int id)
        {
            Programa programa = await _programaService.GetProgramaById(id);
            if (programa == null)
            {
                return NotFound();
            }

            CompetenciaViewModel model = new()
            {
                ProgramaId = programa.Programa_Id,
                TipoCompetencias = _combosHelper.GetComboTipoCompetencia()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCompetencia(CompetenciaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Competencia competencia = new()
                    {
                        Programa = await _context.Programas.FindAsync(model.ProgramaId),
                        Competencia_Nombre = model.Competencia_Nombre,
                        Competencia_Tipo = model.TipoCompetencia,
                        IsActive = model.IsActive
                    };

                    await _competenciaService.CreateCompetenciaAsync(competencia);
                    Programa programa = await _programaService.GetProgramaById(model.ProgramaId);
                    _flashMessage.Info("Registro creado.");
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllCompetencias", programa) });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una competencia con el mismo nombre en este programa.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            model.TipoCompetencias = _combosHelper.GetComboTipoCompetencia();
            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddCompetencia", model) });
        }

        [NoDirectAccess]
        public async Task<IActionResult> EditCompetencia(int id)
        {
            Competencia competencia = await _context.Competencias
                .Include(cp => cp.Programa)
                .FirstOrDefaultAsync(cp => cp.Competencia_Id == id);

            if (competencia == null)
            {
                return NotFound();
            }

            CompetenciaViewModel model = new()
            {
                ProgramaId = competencia.Programa.Programa_Id,
                Competencia_Id = competencia.Competencia_Id,
                Competencia_Nombre = competencia.Competencia_Nombre,
                TipoCompetencia = competencia.Competencia_Tipo,
                IsActive = competencia.IsActive,
                TipoCompetencias = _combosHelper.GetComboTipoCompetencia()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCompetencia(int id, CompetenciaViewModel model)
        {
            if (id != model.Competencia_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Competencia competencia = new()
                    {
                        Competencia_Id = model.Competencia_Id,
                        Competencia_Nombre = model.Competencia_Nombre,
                        IsActive = model.IsActive,
                        Competencia_Tipo = model.TipoCompetencia

                    };
                    await _competenciaService.UdateCompetenciaAsync(competencia);
                    Programa programa = await _context.Programas
                       .Include(p => p.Competencias)
                       .FirstOrDefaultAsync(p => p.Programa_Id == model.ProgramaId);
                    _flashMessage.Confirmation("Registro actualizado.");
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllCompetencias", programa) });

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty,
                            "Ya existe una competencia con el mismo nombre en este programa");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            model.TipoCompetencias = _combosHelper.GetComboTipoCompetencia();
            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "EditCompetencia", model) });
        }

        [HttpGet]
        public async Task<IActionResult> DetailsCompetencia(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Competencia competencia = await _context.Competencias
                .Include(c => c.Programa)
                .FirstOrDefaultAsync(c => c.Competencia_Id == id);
            if (competencia == null)
            {
                return NotFound();
            }

            return View(competencia);
        }

        [NoDirectAccess]
        public async Task<IActionResult> DeleteCompetencia(int id)
        {
            Competencia competencia = await _competenciaService.GetCompetenciaByIdAsync(id);
            if (competencia == null)
            {
                return NotFound();
            }

            try
            {
                await _competenciaService.DeleteCompetenciaByIdAsync(id);
                _flashMessage.Info("Registro desactivado.");
            }
            catch
            {
                _flashMessage.Danger("No se puede desactivar la competencia porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Details), new { Id = competencia.Programa.Programa_Id });
        }
        #endregion
    }
}
