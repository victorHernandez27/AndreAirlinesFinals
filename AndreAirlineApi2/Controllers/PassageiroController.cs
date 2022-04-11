using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using AndreAirlineApi2.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {
        private readonly RepositorioPassageiroImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public PassageiroController(RepositorioPassageiroImplementation respositoy, RegistrarLogService registrarLogService)
        {
            _respositoy = respositoy;
            _registrarLogService = registrarLogService;
        }

        [HttpGet("obter/{id}")]
        public IActionResult Obter(string cpf)
        {
            return Ok(_respositoy.Find(cpf));
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_respositoy.List(orderBy: p => p.Cpf));
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar(Passageiro passageiro)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, passageiro, "Adicionar");
                return Created("", _respositoy.Add(passageiro));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Passageiro passageiro)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(passageiro.Cpf);
                _registrarLogService.RegistrarLog(entidadeAntes, passageiro, "Atualizar");

                _respositoy.Edit(passageiro.Cpf, passageiro);
                return Ok("Passageiro Atualizado com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Atualizar: {ex.Message}");
            }
        }

        [HttpDelete("remover/{cpf}")]
        public IActionResult Remover(string cpf)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(cpf);
                _registrarLogService.RegistrarLog(entidadeAntes, null, "Remover");

                _respositoy.Delete(cpf);
                return Ok("Passageiro Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}