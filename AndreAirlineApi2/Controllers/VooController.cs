using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using AndreAirlineApi2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly RepositorioVooImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public VooController(RepositorioVooImplementation respositoy, RegistrarLogService registrarLogService)
        {
            _respositoy = respositoy;
            _registrarLogService = registrarLogService;
        }

        [HttpGet("obter/{id}")]
        [Authorize]
        public IActionResult Obter(string id)
        {
            return Ok(_respositoy.Find(id));
        }

        [HttpGet("listar")]
        [Authorize]
        public IActionResult Listar()
        {
            return Ok(_respositoy.List(orderBy: p => p.Id));
        }

        [HttpPost("adicionar")]
        [Authorize]
        public IActionResult Adicionar(Voo voo)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, voo, "Adicionar");
                return Created("", _respositoy.Add(voo));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        [Authorize]
        public IActionResult Atualizar(Voo voo)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(voo.Id);
                _registrarLogService.RegistrarLog(entidadeAntes, voo, "Atualizar");

                _respositoy.Edit(voo.Id, voo);
                return Ok("Voo Atualizado com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Atualizar: {ex.Message}");
            }
        }

        [HttpDelete("remover/{id}")]
        [Authorize]
        public IActionResult Remover(string id)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(id);
                _registrarLogService.RegistrarLog(entidadeAntes, null, "Remover");

                _respositoy.Delete(id);
                return Ok("Voo Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}