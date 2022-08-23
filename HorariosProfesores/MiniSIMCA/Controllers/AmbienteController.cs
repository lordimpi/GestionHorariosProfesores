using DataAccess.Data.Entities;
using Infrastructure.Services.Contracts;
using Infrastructure.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSIMCA.Helpers;
using MiniSIMCA.Models;
using Vereyon.Web;
using static MiniSIMCA.Helpers.ModalHelper;

namespace MiniSIMCA.Controllers
{
    public class AmbienteController : Controller
    {
        private readonly IAmbienteService _ambienteService;
        private readonly ICombosHelper _combosHelper;
        private readonly IFlashMessage _flashMessage;

        public AmbienteController(IAmbienteService ambienteService, ICombosHelper combosHelper, IFlashMessage flashMessage)
        {
            _ambienteService = ambienteService;
            _combosHelper = combosHelper;
            this._flashMessage = flashMessage;
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ambiente ambiente = await _ambienteService.GetAmbienteByIdAsync(id);
            if (ambiente == null)
            {
                return NotFound();
            }

            AmbienteViewModel model = new()
            {
                Capacidad = ambiente.Capacidad,
                Id = ambiente.Id,
                Nombre = ambiente.Nombre,
                TipoAmbiente = ambiente.TipoAmbiente,
                TipoAmbientes = _combosHelper.GetComboTipoAmbiente(),
                Ubicacion = ambiente.Ubicacion,
                IsActive = ambiente.IsActive,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AmbienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return NotFound();
                }
                try
                {
                    Ambiente ambiente = await _ambienteService.GetAmbienteByIdAsync(id);
                    ambiente.TipoAmbiente = model.TipoAmbiente;
                    ambiente.Ubicacion = model.Ubicacion;
                    ambiente.Capacidad = model.Capacidad;
                    ambiente.Nombre = model.Nombre;
                    ambiente.TipoAmbiente = model.TipoAmbiente;
                    ambiente.IsActive = model.IsActive;

                    await _ambienteService.UdateAmbienteAsync(ambiente);
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
        
        [NoDirectAccess]
        public async Task<IActionResult> Delete(int id)
        {

            Ambiente ambiente = await _ambienteService.GetAmbienteByIdAsync(id);
            if (ambiente == null)
            {
                return NotFound();
            }

            await _ambienteService.DeleteAmbienteByIdAsync(id);
            _flashMessage.Info("Registro Desactivado.");
            return RedirectToAction(nameof(Index));
        }
    }
}
