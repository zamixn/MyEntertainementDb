using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Tag
    {
        public int id { get; private set; }
        public string Name { get; private set; }

        [JsonConstructor]
        public Tag(int id, string name)
        {
            this.id = id;
            Name = name;
        }
    }
}
