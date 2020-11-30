using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.CodeOnly
{
    public class RatedWatchable
    {
        public WatchableWithCreator watchable;
        public EntryRating rating;

        public static RatedWatchable Parse(DataRow row)
        {
            return new RatedWatchable()
            {
                watchable = WatchableWithCreator.Parse(row),
                rating = EntryRating.ParseEntryRating(row)
            };
        }
    }
}
