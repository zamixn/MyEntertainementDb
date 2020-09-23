using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDB_backend.Models.ExternalSources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDB_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreatorsController : ControllerBase
    {
        // GET: Creators
        [HttpGet]
        public IEnumerable<Creator> Get()
        {
            return Creator.GetList();
        }

        // GET: Creators/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Creator g = Creator.Get(id);
            return Ok(g);
        }

        // POST: Creators
        [HttpPost]
        public IActionResult Post([FromBody] Creator c)
        {
            string uri = "uri?";
            Creator.Create(c);
            return Created(uri, c);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Creator c)
        {
            Creator.Update(id, c);
            return StatusCode(StatusCodes.Status202Accepted, $"\"Response\":\"updated {id}\"");
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Creator.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, $"\"Response\":\"deleted {id}\"");
        }
    }
}
