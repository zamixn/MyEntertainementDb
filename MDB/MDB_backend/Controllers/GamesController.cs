using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MDB_backend.Models;
using MDB_backend.Models.CodeOnly;
using MDB_backend.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MDB_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<GameWithCreator> Get()
        {
            return GameWithCreator.GetList();
        }

        // GET: games/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            GameWithCreator g = GameWithCreator.Get(id);
            if (g == null)
                return NotFound(new ResponseMessage("id not found"));

            return Ok(g);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Game g)
        {
            string uri = "uri?";
            Game.Create(g);
            return Created(uri, g);
        }

        [HttpPut("{id}")]
        public IActionResult Patch(int id, [FromBody] Game g)
        {
            if(Game.Update(id, g))
                return StatusCode(StatusCodes.Status202Accepted, new ResponseMessage($"sucess. updated {id}"));
            return NotFound(new ResponseMessage($"id: '{id}' not found"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(Game.Delete(id))
                return StatusCode(StatusCodes.Status204NoContent, new ResponseMessage($"sucess. deleted {id}"));
            return NotFound(new ResponseMessage($"id: '{id}' not found"));
        }

        [HttpGet("{id}/creators")]
        public IActionResult GetCreators(int id)
        {
            if(!Game.IdExists(id))
                return NotFound(new ResponseMessage($"id: {id} not found"));

            List<Creator> creators = Creator.GetEntryCreators(id);
            if (creators == null)
                return Ok(new List<Creator>());

            return Ok(creators);
        }
    }
}
