using MDB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MDB_backend.Models.SystemUser;

namespace MDB_backend.RestMessages
{
    public class AuthenticateResponse
    {
        public int id { get; private set; }
        public string Username { get; private set; }
        public UserRole Role { get; private set; }
        public string Token { get; private set; }

        public AuthenticateResponse(SystemUser user, string token)
        {
            id = user.id;
            Username = user.Username;
            Role = user.Role;
            Token = token;
        }
    }
}
