using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using AndreAirlineApi2.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly RepositorioUsuarioImplementation _respositoy;
        private readonly RegistrarLogService _registrarLogService;

        public UsuarioController(RepositorioUsuarioImplementation respositoy, RegistrarLogService registrarLogService)
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
        public IActionResult Adicionar(Usuario usuario)
        {
            try
            {
                _registrarLogService.RegistrarLog(null, usuario, "Adicionar");
                return Created("", _respositoy.Add(usuario));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Adicionar: {ex.Message}");
            }

        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar(Usuario usuario)
        {
            try
            {
                var entidadeAntes = _respositoy.Find(usuario.Cpf);
                _registrarLogService.RegistrarLog(entidadeAntes, usuario, "Atualizar");

                _respositoy.Edit(usuario.Cpf, usuario);
                return Ok("Usuario Atualizado com Sucesso.");
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
                return Ok("Usuario Removido com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Remover: {ex.Message}");
            }
        }
    }
}