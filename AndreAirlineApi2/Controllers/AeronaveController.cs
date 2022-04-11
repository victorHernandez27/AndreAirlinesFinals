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
    public class AeronaveController : ControllerBase
    {
        private readonly RepositorioAeronaveImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public AeronaveController(RepositorioAeronaveImplementation respositoy, RegistrarLogService registrarLogService)
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
        public IActionResult Adicionar(Aeronave aeronave)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, aeronave, "Adicionar");
                return Created("", _respositoy.Add(aeronave));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Aeronave aeronave)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(aeronave.Id);
                _registrarLogService.RegistrarLog(entidadeAntes, aeronave, "Atualizar");

                _respositoy.Edit(aeronave.Id, aeronave);
                return Ok("Aeronave Atualizado com Sucesso.");
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
                return Ok("Aeronave Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}