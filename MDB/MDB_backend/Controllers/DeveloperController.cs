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
    public class DeveloperController : ControllerBase
    {
        // GET: Developer
        [HttpGet]
        public IEnumerable<Developer> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Developer($"Dev {index}")).ToArray();
        }

        // GET: Developer/5
        [HttpGet("{id}", Name = "Get")]
        public Developer Get(int id)
        {
            return new Developer($"Dev {id}");
        }

        // POST: Developer
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "Post success";
        }

        // PUT: Developer/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return "Put success";
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Delete success";
        }
    }
}
