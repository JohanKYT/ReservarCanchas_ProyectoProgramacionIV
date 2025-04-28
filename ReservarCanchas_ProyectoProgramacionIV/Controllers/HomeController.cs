using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservarCanchas_ProyectoProgramacionIV.Models;

namespace ReservarCanchas_ProyectoProgramacionIV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public HomeController(ILogger<HomeController> logger, BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Intentar encontrar un usuario en cada tabla
            var administrador = _context.Administrador
                .FirstOrDefault(u => u.Correo == email && u.Password == password);

            var estudiante = _context.Estudiante
                .FirstOrDefault(u => u.Correo == email && u.Password == password);

            var personalMantenimiento = _context.PersonalMantenimiento
                .FirstOrDefault(u => u.Correo == email && u.Password == password);

            // Verificar si se encontró el usuario y redirigir
            if (administrador != null)
            {
                TempData["LoginSuccess"] = "Bienvenido Administrador!";
                return RedirectToAction("Index", "Administradores");
            }
            else if (estudiante != null)
            {
                TempData["LoginSuccess"] = "Bienvenido Estudiante!";
                return RedirectToAction("Index", "Reservas");
            }
            else if (personalMantenimiento != null)
            {
                TempData["LoginSuccess"] = "Bienvenido Personal de Mantenimiento!";
                return RedirectToAction("Index", "Reservas");
            }

            // Si no se encuentra el usuario, mostrar error
            TempData["LoginError"] = "Correo o contraseña incorrectos.";
            return RedirectToAction("Index", "Home");
        }
    }
}
