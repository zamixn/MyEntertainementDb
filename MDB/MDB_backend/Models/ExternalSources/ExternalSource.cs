using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.ExternalSources
{
    public class ExternalSource
    {
        public float Rating { get; private set; }
        public string Link { get; private set; }
        public int RatingCount { get; private set; }
    }
}
