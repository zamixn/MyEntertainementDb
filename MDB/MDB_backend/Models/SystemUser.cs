using MDB_backend.RestMessages;
using MDB_backend.Tools;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MDB_backend.Models
{
    public class SystemUser
    {
        public enum UserRole { Admin = 1, LoggedInUser = 2, Guest = 3, Any = 99 }

        public int id { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }

        [JsonConstructor]
        public SystemUser(int id, string username, string passwordHash, UserRole role)
        {
            this.id = id;
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }

        public static List<SystemUser> GetList()
        {
            string sql = $"SELECT * FROM `systemuser`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<SystemUser> list = new List<SystemUser>();
            foreach (DataRow row in dt.Rows)
            {
                SystemUser user = ParseUser(row);
                list.Add(user);
            }
            return list;
        }

        public static SystemUser GetUserByRequest(string username, string passwordHash)
        {
            string sql = $"SELECT * FROM `systemuser` WHERE `Username`='{username}' AND `PasswordHash`='{passwordHash}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);
            if (dt.Rows.Count > 0)
                return ParseUser(dt.Rows[0]);
            return null;
        }

        public static SystemUser Get(int id)
        {
            string sql = $"SELECT * FROM `systemuser` WHERE `id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);
            if (dt.Rows.Count > 0)
                return ParseUser(dt.Rows[0]);
            return null;
        }


        public static bool Register(SystemUser user)
        {
            if (!user.ValidateUsernameAndPassword())
                return false;

            string sql = $"INSERT INTO `systemuser`(`Username`, `PasswordHash`, `Role`) VALUES ('{user.Username}','{user.PasswordHash}','{(int)UserRole.LoggedInUser}')";

            DatabaseHelper.ExecuteNonQuery(sql);
            return true;
        }


        public static AuthenticateResponse Authenticate(SystemUser systemUser)
        {
            SystemUser user = GetUserByRequest(systemUser.Username, systemUser.PasswordHash);
            if (user == null)
                return null;

            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }


        private static SystemUser ParseUser(DataRow row)
        { 
            return new SystemUser(
                    id: Convert.ToInt32(row["id"]),
                    username: Convert.ToString(row["Username"]),
                    passwordHash: Convert.ToString(row["PasswordHash"]),
                    role: (UserRole)Convert.ToInt32(row["Role"])
                    );
        }

        /// <summary>
        /// returns false if the user is not authenticated or its role is too low
        /// </summary>
        /// <param name="context"></param>
        /// <param name="minimumRoleAllowed"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool GetAuthenticated(HttpContext context, UserRole minimumRoleAllowed, out SystemUser user)
        {
            try
            {
                user = (SystemUser)context.Items[AppSettings.UserInContext];
                if (user == null)
                    return false;

                return (int)user.Role <= (int)minimumRoleAllowed;
            }
            catch
            {
                user = null;
                return false;
            }
        }

        private static string generateJwtToken(SystemUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.AppSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),

                Expires = DateTime.UtcNow.AddSeconds(AppSettings.TokenDurationSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateUsernameAndPassword()
        {
            return !Username.Contains('\'') && !Username.Contains('\"') &&
                    !PasswordHash.Contains('\'') && !PasswordHash.Contains('\"');
        }

    }
}
