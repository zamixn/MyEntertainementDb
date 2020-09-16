using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDB_backend.Models;
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
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Game(index, $"Cool game {index}", (float)rng.NextDouble(), DateTime.Now, $"Cool description {index}", rng.Next(0, 10), DateTime.Now)).ToArray();
        }
    }
}
