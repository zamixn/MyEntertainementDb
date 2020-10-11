using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Tools
{
    public class ResponseMessage
    {
        public string Message;

        [JsonConstructor]
        public ResponseMessage(string message)
        {
            Message = message;
        }

        public static readonly ResponseMessage Unautharized = new ResponseMessage("Unautherized");
        public static readonly ResponseMessage InvalidUserData = new ResponseMessage("Username or password is invalid");
    }
}
