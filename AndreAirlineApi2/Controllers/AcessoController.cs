using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using AndreAirlineApi2.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly RepositorioAcessoImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public AcessoController(RepositorioAcessoImplementation respositoy, RegistrarLogService registrarLogService)
        {
            _respositoy = respositoy;
            _registrarLogService = registrarLogService;
        }

        [HttpGet("obter/{id}")]
        public IActionResult Obter(string id)
        {
            return Ok(_respositoy.Find(id));
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_respositoy.List(orderBy: p => p.Id));
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar(Acesso acesso)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, acesso, "Adicionar");
                return Created("", _respositoy.Add(acesso));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Acesso acesso)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(acesso.Id);
                _registrarLogService.RegistrarLog(entidadeAntes, acesso, "Atualizar");

                _respositoy.Edit(acesso.Id, acesso);
                return Ok("Acesso Atualizado com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Atualizar: {ex.Message}");
            }
        }

        [HttpDelete("remover/{id}")]
        public IActionResult Remover(string id)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(id);
                _registrarLogService.RegistrarLog(entidadeAntes, null, "Remover");

                _respositoy.Delete(id);
                return Ok("Acesso Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}