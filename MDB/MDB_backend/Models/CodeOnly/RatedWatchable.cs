using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.CodeOnly
{
    public class RatedWatchable
    {
        public Watchable watchable;
        public EntryRating rating;

        public static RatedWatchable Parse(DataRow row)
        {
            return new RatedWatchable()
            {
                watchable = Watchable.Parse(row),
                rating = EntryRating.ParseEntryRating(row)
            };
        }
    }
}
