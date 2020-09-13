using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class WatchableGenre
    {
        public enum WatchableGenreType
        {
            FilmNoir = 1,
            Comedy = 2,
            Family = 3,
            Drama = 4,
            Romance = 5,
            Mystery = 6,
            Crime = 7,
            Documentary = 8,
            History = 9,
            Musical = 10,
            Western = 11,
            War = 12,
            News = 13,
            Action = 14,
            Animation = 15,
            Fantasy = 16,
            SciFi = 17,
            Short = 18,
            Thriller = 19,
            RealityTv = 20,
            Horror = 21,
            GameShow = 22,
            Music = 23,
            Sport = 24,
            Biography = 25,
            TalkShow = 26,
            Adult = 27
        }

        public WatchableGenreType Genre { get; private set; }
    }
}
