using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Developer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Developer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
