using DataAccess.Data.Entities;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSIMCA.Models;

namespace MiniSIMCA.Controllers
{
    public class DocenteController : Controller
    {
        private readonly IDocenteService _docenteService;

        public DocenteController(IDocenteService docenteService)
        {
            _docenteService = docenteService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _docenteService.GetAllDocentesAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocenteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model == null)
                    {
                        return NotFound();
                    }

                    Docente docente = new()
                    {
                        Docente_Apellidos = model.Docente_Apellidos,
                        Docente_Area = model.Docente_Area,
                        Docente_Identificacion = model.Docente_Identificacion,
                        Docente_Nombres = model.Docente_Nombres,
                        Docente_Tipo = model.Docente_Tipo,
                        Docente_TipoContrato = model.Docente_Tipo,
                        Docente_TipoIdentificacion = model.Docente_Tipo,
                        IsActive = model.IsActive
                    };
                    await _docenteService.CreateDocenteAsync(docente);
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
            return View(model);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Docente docente = await _docenteService.GetDocenteByIdAsync(id);
            DocenteViewModel model = new()
            {
                Docente_Apellidos = docente.Docente_Apellidos,
                Docente_Area = docente.Docente_Area,
                Docente_Identificacion = docente.Docente_Identificacion,
                Docente_Nombres = docente.Docente_Nombres,
                Docente_Tipo = docente.Docente_Tipo,
                Docente_TipoContrato = docente.Docente_TipoContrato,
                Docente_TipoIdentificacion = docente.Docente_TipoIdentificacion,
                IsActive = docente.IsActive
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, DocenteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return NotFound();
                }

                try
                {
                    Docente docente = await _docenteService.GetDocenteByIdAsync(id);
                    docente.Docente_TipoIdentificacion = model.Docente_TipoIdentificacion;
                    docente.Docente_Identificacion = model.Docente_Identificacion;
                    docente.IsActive = model.IsActive;
                    docente.Docente_Tipo = model.Docente_Tipo;
                    docente.Docente_Apellidos = model.Docente_Apellidos;
                    docente.Docente_Nombres = model.Docente_Nombres;
                    docente.Docente_Area = model.Docente_Area;
                    docente.Docente_TipoContrato = model.Docente_TipoContrato;

                    await _docenteService.UdateDocenteAsync(docente);
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
            return View(model);

        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Docente docente = await _docenteService.GetDocenteByIdAsync(id);
            if (docente == null)
            {
                return NotFound();
            }
            return View(docente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Docente docente = await _docenteService.GetDocenteByIdAsync(id);
            if (docente == null)
            {
                return NotFound();
            }
            return View(docente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _docenteService.DeleteDocenteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
