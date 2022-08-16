using DataAccess.Data.Entities;
using DataAccess.Data.Enums;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSIMCA.Helpers;
using MiniSIMCA.Models;
using Vereyon.Web;

namespace MiniSIMCA.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DocenteController : Controller
    {
        private readonly IDocenteService _docenteService;
        private readonly IUserHelper _userHelper;
        private readonly IFlashMessage _flashMessage;
        private readonly ICombosHelper _combosHelper;

        public DocenteController(IDocenteService docenteService, IUserHelper userHelper, IFlashMessage flashMessage, ICombosHelper combosHelper)
        {
            _docenteService = docenteService;
            _userHelper = userHelper;
            _flashMessage = flashMessage;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _docenteService.GetAllDocentesAsync());
        }

        public IActionResult Create()
        {
            DocenteViewModel model = new()
            {
                Id = Guid.Empty.ToString(),
                TipoContratos = _combosHelper.GetComboTipoContrato(),
                TiposIdentificacion = _combosHelper.GetComboTipoIdentificacion(),
                TipoDocentes = _combosHelper.GetComboTipoDocente(),
            };

            return View(model);
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

                    AddUserViewModel addUserViewModel = new()
                    {
                        Docente_Apellidos = model.Docente_Apellidos,
                        Docente_Nombres = model.Docente_Nombres,
                        Docente_Identificacion = model.Docente_Identificacion,
                        Password = model.Docente_Password,
                        UserName = model.Docente_Email,
                        PasswordConfirm = model.Docente_PasswordConfirm,
                        UserType = UserType.User,
                        IsActive = model.IsActive,
                        Id = model.Id,
                        Docente_Area = model.Docente_Area,
                        Docente_Tipo = model.TipoDocenteId,
                        Docente_TipoContrato = model.ContratoId,
                        Docente_TipoIdentificacion = model.TipoIdentificacionId
                    };

                    User user = await _userHelper.AddUserAsync(addUserViewModel);
                    if (user == null)
                    {
                        _flashMessage.Danger("Este correo ya está siendo usado.");
                        return View(model);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un docente con el mismo nombre.");
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
            model.TiposIdentificacion = _combosHelper.GetComboTipoIdentificacion();
            model.TipoDocentes = _combosHelper.GetComboTipoDocente();
            model.TipoContratos = _combosHelper.GetComboTipoContrato();
            return View(model);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User docente = await _docenteService.GetDocenteByIdAsync(id);
            DocenteViewModel model = new()
            {
                Docente_Apellidos = docente.Docente_Apellidos,
                Docente_Area = docente.Docente_Area,
                Docente_Identificacion = docente.Docente_Identificacion,
                Docente_Nombres = docente.Docente_Nombres,
                TipoDocentes = _combosHelper.GetComboTipoDocente(),
                TipoContratos = _combosHelper.GetComboTipoContrato(),
                TiposIdentificacion = _combosHelper.GetComboTipoIdentificacion(),
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
                    User docente = await _docenteService.GetDocenteByIdAsync(id);
                    docente.Docente_TipoIdentificacion = model.TiposIdentificacion.ToString();
                    docente.Docente_Identificacion = model.Docente_Identificacion;
                    docente.IsActive = model.IsActive;
                    docente.Docente_Tipo = model.TipoDocentes.ToString();
                    docente.Docente_Apellidos = model.Docente_Apellidos;
                    docente.Docente_Nombres = model.Docente_Nombres;
                    docente.Docente_Area = model.Docente_Area;
                    docente.Docente_TipoContrato = model.TipoContratos.ToString();

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
            User docente = await _docenteService.GetDocenteByIdAsync(id);
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

            User docente = await _docenteService.GetDocenteByIdAsync(id);
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
