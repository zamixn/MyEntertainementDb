using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDB_backend.Models;
using MDB_backend.Tools;
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
        public IActionResult Get(int id)
        {
            Watchable g = Watchable.Get(id);
            if (g == null)
                return NotFound(new ResponseMessage($"id: '{id}' not found"));
            return Ok(g);
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
            if(Watchable.Update(id, m))
                return StatusCode(StatusCodes.Status202Accepted, new ResponseMessage($"sucess. updated {id}"));
            return NotFound(new ResponseMessage($"id: '{id}' not found"));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(Watchable.Delete(id))
                return StatusCode(StatusCodes.Status204NoContent, new ResponseMessage($"sucess. deleted {id}"));
            return NotFound(new ResponseMessage($"id: '{id}' not found"));
        }
    }
}
