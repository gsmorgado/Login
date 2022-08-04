using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Login.Repositorios.Repository;
using Login.Models;

namespace Login.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepostiroy _userRepository;
        public UserController(IUserRepostiroy userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Action form Login user
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Action Form Register user
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Action Login User
        /// </summary>
        /// <param name="_usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(UserDto _usuario)
        {
            var resp = "";

            if (ModelState.IsValid)
            {

                resp = await _userRepository.Login(_usuario.Email, _usuario.Password);
               
            }
            else
            {
                return View();
            }

            if (resp == "ok")
            {
                // Cookie de session
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Email, _usuario.Email)
                        // new Claim("Correo", usuario.Email)
                    };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // add la cokie 
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Test", "Home");
            }
            else if (resp == "password_wrong")
            {
                ViewData["Mensaje"] = "Password Incorrecto!";
                return View();
            }
            else if (resp == "usuario_wrong")
            {
                ViewData["Mensaje"] = "Usuario Incorrecto!";
                return View();
            }
            else
            {
                return View();
            }

        }
        /// <summary>
        /// Action Register User
        /// </summary>
        /// <param name="_usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(UserDto _usuario)
        {
            var resp="";

            if (ModelState.IsValid)
            {
                resp = await _userRepository.Register(_usuario, _usuario.Password);

            }
            if (resp == "user_exist")
            {
                ViewData["Mensaje"] = "Usuario ya existe!";
                return View();

            }
            else if (resp == "ok")
            {
                return RedirectToAction("Index", "User");
            }
            else {
                return View();
            }
        }
        /// <summary>
        /// Exit 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Salir()
        {
            // delete cokie 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "User");
        }
    
    }
}
