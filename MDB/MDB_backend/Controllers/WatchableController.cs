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
    public class WatchableController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<WatchableEntry> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WatchableEntry(index, $"Cool movie {index}", (float)rng.NextDouble(), DateTime.Now, $"Cool description {index}", rng.Next(0, 10), DateTime.Now, WatchableEntry.WatchableType.Movie)).ToArray();
        }
    }
}