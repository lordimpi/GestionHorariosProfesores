using DataAccess.Data.Entities;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSIMCA.Helpers;
using MiniSIMCA.Models;

namespace MiniSIMCA.Controllers
{
    public class AmbienteController : Controller
    {
        private readonly IAmbienteService _ambienteService;
        private readonly ICombosHelper _combosHelper;

        public AmbienteController(IAmbienteService ambienteService, ICombosHelper combosHelper)
        {
            _ambienteService = ambienteService;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Ambiente> ambientes = await _ambienteService.GetAllAmbientesAsync();
            return View(ambientes);
        }

        public IActionResult Create()
        {
            AmbienteViewModel model = new()
            {
                TipoAmbientes = _combosHelper.GetComboTipoAmbiente()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AmbienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model == null)
                    {
                        return NotFound();
                    }
                    Ambiente ambiente = new()
                    {
                        Capacidad = model.Capacidad,
                        Nombre = model.Nombre,
                        TipoAmbiente = model.TipoAmbiente,
                        Ubicacion = model.Ubicacion,
                        IsActive = model.IsActive
                    };
                    await _ambienteService.CreateAmbienteAsync(ambiente);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un ambiente con el mismo nombre.");
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

            model.TipoAmbientes = _combosHelper.GetComboTipoAmbiente();
            return View(model);
        }
    }
}
