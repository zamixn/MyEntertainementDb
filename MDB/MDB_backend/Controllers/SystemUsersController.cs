using System;
using System.Collections.Generic;
using MDB_backend.Models;
using MDB_backend.Models.CodeOnly;
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

            AuthenticateResponse response = user.Login();

            if (response == null)
                return BadRequest(ResponseMessage.InvalidUserData);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult PostLogin([FromBody] SystemUser user)
        {
            AuthenticateResponse response = user.Login();

            if (response == null)
                return BadRequest(ResponseMessage.InvalidUserData);

            return Ok(response);
        }

        [HttpPatch("{id}/logout")]
        public IActionResult Logout(int id)
        {
            if (SystemUser.GetAuthenticated(HttpContext, UserRole.Any, out SystemUser usr) && usr.id == id)
            {
                usr.Logout();
                return Ok(new ResponseMessage("Logged out"));
            }
            return Unauthorized(ResponseMessage.Unautharized);
        }

        [HttpPost("{id}/rateentry")]
        public IActionResult PostRating(int id, [FromBody] EntryRating rating)
        {
            if (SystemUser.GetAuthenticated(HttpContext, UserRole.Any, out SystemUser usr) && usr.id == id && rating.user_id == id)
            {
                if (!EntryRating.Exists(rating))
                {
                    if (EntryRating.Create(rating))
                        return Ok(rating);
                }
                else
                {
                    if (EntryRating.Update(rating))
                        return Ok(rating);
                }

                return BadRequest(new ResponseMessage("Failed to rate entry"));
            }
            return Unauthorized(ResponseMessage.Unautharized);
        }


        [HttpGet("{id}/games")]
        public IActionResult GetGames(int id)
        {
            if (SystemUser.GetAuthenticated(HttpContext, UserRole.Any, out SystemUser usr) && usr.id == id)
            {
                return Ok(usr.GetRatedGames());
            }
            return Unauthorized(ResponseMessage.Unautharized);
        }
        [HttpGet("{id}/watchables")]
        public IActionResult GetWatchables(int id)
        {
            if (SystemUser.GetAuthenticated(HttpContext, UserRole.Any, out SystemUser usr) && usr.id == id)
            {
                return Ok(usr.GetRatedWatchables());
            }
            return Unauthorized(ResponseMessage.Unautharized);
        }
    }
}
