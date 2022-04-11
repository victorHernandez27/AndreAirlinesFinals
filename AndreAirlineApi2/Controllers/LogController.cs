using AndreAirlineApi2.Data.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly RepositorioLogImplementation _respositoy;

        public LogController(RepositorioLogImplementation respositoy)
        {
            _respositoy = respositoy;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_respositoy.List(orderBy: p => p.Id));
        }
    }
}