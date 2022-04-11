using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using AndreAirlineApi2.Service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportoController : ControllerBase
    {
        private readonly RepositorioAeroportoImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public AeroportoController(RepositorioAeroportoImplementation respositoy, RegistrarLogService registrarLogService)
        {
            _respositoy = respositoy;
            _registrarLogService = registrarLogService;
        }

        [HttpGet("obter/{id}")]
        public IActionResult Obter(string sigla)
        {
            return Ok(_respositoy.Find(sigla));
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_respositoy.List(orderBy: p => p.Sigla));
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar(Aeroporto aeroporto)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, aeroporto, "Adicionar");
                return Created("", _respositoy.Add(aeroporto));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Aeroporto aeroporto)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(aeroporto.Sigla);
                _registrarLogService.RegistrarLog(entidadeAntes, aeroporto, "Atualizar");

                _respositoy.Edit(aeroporto.Sigla, aeroporto);
                return Ok("Aeroporto Atualizado com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Atualizar: {ex.Message}");
            }
        }

        [HttpDelete("remover/{sigla}")]
        public IActionResult Remover(string sigla)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(sigla);
                _registrarLogService.RegistrarLog(entidadeAntes, null, "Remover");

                _respositoy.Delete(sigla);
                return Ok("Aeroporto Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}