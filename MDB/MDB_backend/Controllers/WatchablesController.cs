using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDB_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDB_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WatchablesController : ControllerBase
    {
        // GET: Movies
        [HttpGet]
        public IEnumerable<Watchable> Get()
        {
            return Watchable.GetList();
        }

        // GET: Movies/5
        [HttpGet("{id}")]
        public Watchable Get(int id)
        {
            return Watchable.Get(id);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Watchable m)
        {
            string uri = "uri?";
            m = Watchable.Create(m);
            return Created(uri, m);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Watchable m)
        {
            Watchable.Update(id, m);
            return StatusCode(StatusCodes.Status202Accepted, $"\"Response\":\"updated {id}\"");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Watchable.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, $"\"Response\":\"deleted {id}\"");
        }
    }
}
