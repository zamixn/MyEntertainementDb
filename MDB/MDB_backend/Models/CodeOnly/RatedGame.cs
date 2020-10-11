using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.CodeOnly
{
    public class RatedGame
    {
        public Game game;
        public EntryRating rating;

        public static RatedGame Parse(DataRow row)
        {
            return new RatedGame() { 
                game = Game.Parse(row), 
                rating = EntryRating.ParseEntryRating(row) };
        }
    }
}
