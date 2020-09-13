using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.ExternalSources
{
    public class MetacriticSource : ExternalSource
    {
        public float UserRating { get; private set; }
        public int UserRatingCount { get; private set; }
    }
}
