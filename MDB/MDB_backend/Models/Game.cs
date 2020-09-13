using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Game : Entry
    {
        public int TimesPlayed { get; private set; }
        public DateTime LastPlayed { get; private set; }

        public Game(int id, string title, float myRating, DateTime releaseData, string description, int timesPlayed, DateTime lastPlayed)
            : base(id, title, myRating, releaseData, description)
        {
            TimesPlayed = timesPlayed;
            LastPlayed = lastPlayed;
        }




    }
}
