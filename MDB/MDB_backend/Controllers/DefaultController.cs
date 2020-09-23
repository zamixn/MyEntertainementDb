using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDB_backend.Controllers
{
    [Route("{*url}", Order = int.MaxValue)]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet()] 
        public IActionResult Get() 
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        [HttpPost()]
        public IActionResult Post()
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        [HttpPut()]
        public IActionResult Put()
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        [HttpPatch()]
        public IActionResult Patch()
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        [HttpDelete()]
        public IActionResult Delete()
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
