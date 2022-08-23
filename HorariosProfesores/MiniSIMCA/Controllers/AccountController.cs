using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using MiniSIMCA.Helpers;
using MiniSIMCA.Models;

namespace MiniSIMCA.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly ApplicationDbContext _context;

        public AccountController(IUserHelper userHelper, ApplicationDbContext context)
        {
            _userHelper = userHelper;
            _context = context;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Details()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            UserDetailsViewModel model = new()
            {
                UserName = user.UserName,
                Docente_Apellidos = user.Docente_Apellidos,
                Docente_Area = user.Docente_Area,
                Docente_Identificacion = user.Docente_Identificacion,
                Docente_Nombres = user.Docente_Nombres,
                Docente_Tipo = user.Docente_Tipo,
                Docente_TipoContrato = user.Docente_TipoContrato,
                Docente_TipoIdentificacion = user.Docente_TipoIdentificacion,
                IsActive = user.IsActive,
                UserType = user.UserType
            };

            return View(model);
        }

        public IActionResult Register()
        {
            AddUserViewModel model = new()
            {
                Id = Guid.Empty.ToString(),
                UserType = UserType.User,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userHelper.AddUserAsync(model);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado.");
                    return View(model);
                }

                LoginViewModel loginViewModel = new()
                {
                    Password = model.Password,
                    RememberMe = false,
                    UserName = model.UserName
                };

                var result2 = await _userHelper.LoginAsync(loginViewModel);

                if (result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }


    }
}
