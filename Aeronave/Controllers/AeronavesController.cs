using Aeronave.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Model;

namespace Aeronave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeronavesController : ControllerBase
    {
        private readonly AeronaveService _aeronaveService;
        public AeronavesController(AeronaveService aeronaveService)
        {
            _aeronaveService = aeronaveService;
        }

        // GET: api/<AeronaveController>
        [HttpGet]
        public ActionResult<List<Model.Aeronave>> Get() => _aeronaveService.Get();

        // GET api/<AeronaveController>/5
        [HttpGet("{id}")]
        public ActionResult<Model.Aeronave> Get(string id)
        {
            var aeronave = _aeronaveService.Get(id);
            if (aeronave == null)
                return NotFound();
            return aeronave;
        }

        // POST api/<AeronaveController>
        [HttpPost]
        public ActionResult<Model.Aeronave> Post([FromBody] Model.Aeronave aeronave) => _aeronaveService.Create(aeronave);

        // PUT api/<AeronaveController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Model.Aeronave aeronave)
        {
            var aeronaveGet = _aeronaveService.Get(id);
            if (aeronaveGet == null)
                return NotFound(id);
            _aeronaveService.Update(id, aeronave);
            return Ok();
        }

        // DELETE api/<AeronaveController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var aeronve = _aeronaveService.Get(id);
            if (aeronve == null)
                return NotFound(id);
            _aeronaveService.Remove(id);
            return Ok();
        }
    }
}
