using DataAccess.Data;
using DataAccess.Data.Entities;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSIMCA.Helpers;
using Vereyon.Web;
using static MiniSIMCA.Helpers.ModalHelper;

namespace MiniSIMCA.Controllers
{
    public class ProgramasController : Controller
    {
        private readonly IProgramaService _service;
        private readonly IFlashMessage _flashMessage;
        private readonly ApplicationDbContext _context;

        public ProgramasController(IProgramaService service, IFlashMessage flashMessage,
            ApplicationDbContext context)
        {
            _service = service;
            _flashMessage = flashMessage;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetProgramas());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programa Programa = await _service.GetProgramaById(id);
            if (Programa == null)
            {
                return NotFound();
            }

            return View(Programa);
        }

        [NoDirectAccess]
        public async Task<IActionResult> Delete(int? id)
        {
            Programa programa = await _service.GetProgramaById(id);
            try
            {
                await _service.DeletePrograma(id);
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
                Programa Programa = await _service.GetProgramaById(id);
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
                        await _service.CreatePrograma(programa);
                        _flashMessage.Info("Registro creado.");
                    }
                    else //Update
                    {
                        programa.Programa_Id = id;
                        await _service.ModifyPrograma(programa);
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
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProgramas", _service.GetProgramas()) });
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                    return View(programa);
                }
                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProgramas", _service.GetProgramas()) });
            }
            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddOrEdit", programa) });
        }
    }
}
