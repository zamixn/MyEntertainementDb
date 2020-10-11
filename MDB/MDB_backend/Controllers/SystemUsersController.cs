using System;
using System.Collections.Generic;
using MDB_backend.Models;
using MDB_backend.RestMessages;
using MDB_backend.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MDB_backend.Models.SystemUser;


namespace MDB_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SystemUsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            if (SystemUser.GetAuthenticated(HttpContext, UserRole.Admin, out SystemUser usr))
            {
                return Ok(SystemUser.GetList());
            }
            return Unauthorized(ResponseMessage.Unautharized);
        }


        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            if (SystemUser.GetAuthenticated(HttpContext, UserRole.Any, out SystemUser usr) && usr.id == id)
            {
                SystemUser user = SystemUser.Get(id);
                if (user == null)
                    return NotFound(new ResponseMessage($"id:{id} not found"));

                return Ok(user);
            }
            return Unauthorized(ResponseMessage.Unautharized);
        }



        [HttpPost("register")]
        public IActionResult PostRegister([FromBody] SystemUser user)
        {
            if(!SystemUser.Register(user))
                return BadRequest(ResponseMessage.InvalidUserData);

            AuthenticateResponse response = SystemUser.Authenticate(user);

            if (response == null)
                return BadRequest(ResponseMessage.InvalidUserData);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult PostLogin([FromBody] SystemUser user)
        {
            AuthenticateResponse response = SystemUser.Authenticate(user);

            if (response == null)
                return BadRequest(ResponseMessage.InvalidUserData);

            return Ok(response);
        }
    }
}
