using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using AndreAirlineApi2.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private readonly RepositorioPassagemImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public PassagemController(RepositorioPassagemImplementation respositoy, RegistrarLogService registrarLogService)
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
        public IActionResult Adicionar(Passagem passagem)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, passagem, "Adicionar");
                return Created("", _respositoy.Add(passagem));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Passagem passagem)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(passagem.Id);
                _registrarLogService.RegistrarLog(entidadeAntes, passagem, "Atualizar");

                _respositoy.Edit(passagem.Id, passagem);
                return Ok("Passagem Atualizado com Sucesso.");
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
                return Ok("Passagem Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}