using Microsoft.AspNetCore.Mvc;
using Protecto_MVC.API;
using Protecto_MVC.Models;
using System.Diagnostics;

namespace Protecto_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Guayos_Hombre()
        {
            return View();
        }
        public IActionResult Futsal_Hombre()
        {
            return View();
        }
        public IActionResult Sintetica_Hombre()
        {
            return View();
        }
        public IActionResult Guayos_Mujer()
        {
            return View();
        }
        public IActionResult Futsal_Mujer()
        {
            return View();
        }
        public IActionResult Sintetica_Mujer()
        {
            return View();
        }
        public IActionResult Guayos_Niño()
        {
            return View();
        }
        public IActionResult Futsal_Niño()
        {
            return View();
        }
        public IActionResult Sintetica_Niño()
        {
            return View();
        }
        public IActionResult Accesorios()
        {
            return View();
        }
        public IActionResult Guia_Talla()
        {
            return View();
        }
        public IActionResult Seguir_Envio()
        {
            return View();
        }
        public IActionResult Acerca_Nosotros()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }

        public async Task<IActionResult> User()
        {
            UserAPI repository = new UserAPI();
            Debug.WriteLine("Mensaje de depuración: Información importante aquí.");
            List<User> users = new List<User>();
            users = await repository.GetUsersRequest();

            return View(users);
        }

        public async Task<IActionResult> CreateUser(User newUser)
        {
            UserAPI repository = new UserAPI();
            // Llamar al método de tu UserAPI para crear un nuevo usuario
            User usuarioCreado = await repository.CreateUser(newUser);
            return RedirectToAction("User", "Home");
        }

        public async Task<IActionResult> DeleteUser(string username)
        {
            UserAPI repository = new UserAPI();
            // Llamar al método de tu UserAPI
            await repository.DeleteUser(username);
            return RedirectToAction("User", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}