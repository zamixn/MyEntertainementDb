using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class GameGenre
    {
        public enum GameGenreType
        { 
            Action = 1,
            Adventure = 2,
            FPS = 3,
            Fighting = 4,
            Platformer = 5,
            Puzzle = 6,
            Racing = 7,
            RealTime = 8,
            RPG = 9,
            Simulation = 10,
            Sports = 11,
            Strategy = 12,
            ThirdPerson = 13,
            TurnBased = 14,
            War = 15
        }

        public int id { get; private set; }
        public GameGenreType Type { get; private set; }

        [JsonConstructor]
        public GameGenre(int id, GameGenreType type)
        {
            this.id = id;
            Type = type;
        }
    }
}
