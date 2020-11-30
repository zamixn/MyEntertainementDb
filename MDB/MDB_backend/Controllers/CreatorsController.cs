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
            if(g == null)
                return NotFound(new ResponseMessage($"id: '{id}' not found"));
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
            if(Creator.Update(id, c))
                return StatusCode(StatusCodes.Status202Accepted, new ResponseMessage($"sucess. updated {id}"));
            return NotFound(new ResponseMessage($"id: '{id}' not found"));
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(Creator.Delete(id))
                return StatusCode(StatusCodes.Status204NoContent, new ResponseMessage($"sucess. deleted {id}"));
            return NotFound(new ResponseMessage($"id: '{id}' not found"));
        }
    }
}
