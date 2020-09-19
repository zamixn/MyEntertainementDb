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
    public class MoviesController : ControllerBase
    {
        // GET: Movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return Movie.GetMovies();
        }

        // GET: Movies/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return Movie.GetMovie(id);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Movie m)
        {
            string uri = "uri?";
            m = Movie.Create(m);
            return Created(uri, m);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Movie m)
        {
            Movie.Update(id, m);
            return StatusCode(StatusCodes.Status202Accepted, $"\"Response\":\"updated {id}\"");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Movie.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent, $"\"Response\":\"deleted {id}\"");
        }
    }
}
