using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class WatchableEntry : Entry
    {
        public enum WatchableType
        {
            Movie = 1,
            TvMiniSeries = 2,
            TvMovie = 3,
            TvSeries = 4,
            Video = 5
        }

        public int TimesSeen { get; private set; }
        public DateTime LastSeen { get; private set; }
        public WatchableType Type { get; private set; }

        public WatchableEntry(int id, string title, float myRating, DateTime releaseData, string description, int timesSeen, DateTime lastSeen, WatchableType type)
            : base(id, title, myRating, releaseData, description)
        {
            TimesSeen = timesSeen;
            LastSeen = lastSeen;
            Type = type;
        }
    }
}
