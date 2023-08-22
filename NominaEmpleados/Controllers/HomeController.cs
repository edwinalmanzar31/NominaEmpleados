using Microsoft.AspNetCore.Mvc;
using NominaEmpleados.Models;
using System.Diagnostics;
using NominaEmpleados.Servicios;
using System.Linq;

namespace NominaEmpleados.Controllers
{
    public class HomeController : Controller
    {
        NominaSrv Srv = new NominaSrv();

        static readonly NominaVM oNomina = new NominaVM();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(oNomina);
        }

        [HttpPost]
        public IActionResult CalcularNomina(NominaVM NominaVM)
        {
            if (!oNomina.Listado.Exists(r => r.Codigo == NominaVM.oNomina.Codigo))
            {
                oNomina.Listado.Add(Srv.CalcularNomina(NominaVM.oNomina));
                Srv.LimpiarObjetoNomina(oNomina);
            }
            else
            {
                oNomina.Error = true;
                oNomina.ErrorMessage = "Codigo de empleado ya existe en el listado";
            }

            return RedirectToAction("Index", "Home");
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
    }
}