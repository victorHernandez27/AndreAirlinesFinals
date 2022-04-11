using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using AndreAirlineApi2.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly RepositorioClasseImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public ClasseController(RepositorioClasseImplementation respositoy, RegistrarLogService registrarLogService)
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
        public IActionResult Adicionar(Classe classe)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, classe, "Adicionar");
                return Created("", _respositoy.Add(classe));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Classe classe)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(classe.Id);
                _registrarLogService.RegistrarLog(entidadeAntes, classe, "Atualizar");

                _respositoy.Edit(classe.Id, classe);
                return Ok("Classe Atualizado com Sucesso.");
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
                return Ok("Classe Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}