using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MDB_backend.Models;
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
        public IEnumerable<Game> Get()
        {
            return Game.GetList();
        }

        // GET: games/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Game g = Game.Get(id);
            return Ok(g);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Game g)
        {
            string uri = "uri?";
            Game.Create(g);
            return Created(uri, g);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Game g)
        {
            Game.Update(id, g);
            return StatusCode(StatusCodes.Status202Accepted, $"\"Response\":\"updated {id}\"");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Game.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, $"\"Response\":\"deleted {id}\"");
        }
    }
}
