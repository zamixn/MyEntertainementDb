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
    public class SeriesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Series> Get()
        {
            return Series.GetSeries();
        }

        [HttpGet("{id}")]
        public Series Get(int id)
        {
            return Series.GetSeries(id);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Series s)
        {
            string uri = "uri?";
            s = Series.Create(s);
            return Created(uri, s);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Series s)
        {
            Series.Update(id, s);
            return StatusCode(StatusCodes.Status202Accepted, $"\"Response\":\"updated {id}\"");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Series.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, $"\"Response\":\"deleted {id}\"");
        }
    }
}
