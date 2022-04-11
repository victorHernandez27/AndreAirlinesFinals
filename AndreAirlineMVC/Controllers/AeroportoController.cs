using AndreAirlineApi2.Data.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace AndreAirlineMVC.Controllers
{
    public class AeroportoController : Controller
    {
        private readonly RepositorioAeroportoImplementation _respositoy;

        public AeroportoController(RepositorioAeroportoImplementation respositoy)
        {
            _respositoy = respositoy;
        }

        public IActionResult Index()
        {
            return View(_respositoy.List(orderBy: p => p.Sigla));
        }
    }
}
