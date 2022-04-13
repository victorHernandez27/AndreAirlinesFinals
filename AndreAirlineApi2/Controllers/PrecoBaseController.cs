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
    public class PrecoBaseController : ControllerBase
    {
        private readonly RepositorioPrecoBaseImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public PrecoBaseController(RepositorioPrecoBaseImplementation respositoy, RegistrarLogService registrarLogService)
        {
            _respositoy = respositoy;
            _registrarLogService = registrarLogService;
        }

        [HttpGet("obter/{id}")]
        [Authorize(Roles = "manager")]
        public IActionResult Obter(string id)
        {
            return Ok(_respositoy.Find(id));
        }

        [HttpGet("listar")]
        [Authorize(Roles = "manager")]
        public IActionResult Listar()
        {
            return Ok(_respositoy.List(orderBy: p => p.Id));
        }

        [HttpPost("adicionar")]
        [Authorize(Roles = "manager")]
        public IActionResult Adicionar(PrecoBase precoBase)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, precoBase, "Adicionar");
                return Created("", _respositoy.Add(precoBase));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        [Authorize(Roles = "manager")]
        public IActionResult Atualizar(PrecoBase precoBase)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(precoBase.Id);
                _registrarLogService.RegistrarLog(entidadeAntes, precoBase, "Atualizar");

                _respositoy.Edit(precoBase.Id, precoBase);
                return Ok("PrecoBase Atualizado com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Atualizar: {ex.Message}");
            }
        }

        [HttpDelete("remover/{id}")]
        [Authorize(Roles = "manager")]
        public IActionResult Remover(string id)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(id);
                _registrarLogService.RegistrarLog(entidadeAntes, null, "Remover");

                _respositoy.Delete(id);
                return Ok("PrecoBase Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}