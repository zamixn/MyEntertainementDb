using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class ExternalSource
    {
        public double Rating { get; private set; }
        public string Link { get; private set; }
        public int RatingCount { get; private set; }
        public int id { get; private set; }

        [JsonConstructor]
        public ExternalSource(double rating, string link, int ratingCount, int id)
        {
            Rating = rating;
            Link = link;
            RatingCount = ratingCount;
            this.id = id;
        }
    }
}
