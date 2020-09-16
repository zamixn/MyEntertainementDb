using MDB_backend.Tools;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Game : Entry
    {
        public int TimesPlayed { get; private set; }
        public DateTime LastPlayed { get; private set; }

        public Game() : base()
        {
        }

        [JsonConstructor]
        public Game(int id, string title, double myRating, DateTime releaseDate, string description, int timesPlayed, DateTime lastPlayed)
            : base(id, title, myRating, releaseDate, description)
        {
            TimesPlayed = timesPlayed;
            LastPlayed = lastPlayed;
        }


        public static List<Game> GetGames()
        {
            string sql = $"SELECT * FROM `game` LEFT JOIN `entry` ON `game`.`id`=`entry`.`id`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<Game> list = new List<Game>();
            foreach (DataRow row in dt.Rows)
            {
                Game drone = new Game(
                    id: Convert.ToInt32(row["id"]),
                    title: Convert.ToString(row["Title"]),
                    myRating: Convert.ToDouble(row["Rating"]),
                    releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                    description: Convert.ToString(row["Description"]),
                    timesPlayed: Convert.ToInt32(row["TimesPlayed"]),
                    lastPlayed: Convert.ToDateTime(row["LastPlayed"])
                    );
                list.Add(drone);
            }
            return list;
        }

        public static Game GetGame(int id)
        {
            string sql = $"SELECT * FROM `game` LEFT JOIN `entry` ON `game`.`id`=`entry`.`id` WHERE `game`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            if (dt.Rows.Count <= 0)
                return null;
            var row = dt.Rows[0];
            return new Game(
                   id: Convert.ToInt32(row["id"]),
                   title: Convert.ToString(row["Title"]),
                   myRating: Convert.ToDouble(row["Rating"]),
                   releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                   description: Convert.ToString(row["Description"]),
                   timesPlayed: Convert.ToInt32(row["TimesPlayed"]),
                   lastPlayed: Convert.ToDateTime(row["LastPlayed"])
                   );

        }

        public static bool CreateGame(Game g)
        {
            int id = Entry.GetAutoIncrament(); 
            g.CreateEntry(id);

            string sql = $"INSERT INTO `game`(`id`, `TimesPlayed`, `LastPlayed`, `ReleaseDate`) VALUES ('{id}','{g.TimesPlayed}','{g.LastPlayed}','{g.ReleaseDate}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Update(int id, Game g)
        {
            g.UpdateEntry(id);

            string sql = $"UPDATE `game` SET `TimesPlayed`='{g.TimesPlayed}',`LastPlayed`='{g.LastPlayed}',`ReleaseDate`='{g.ReleaseDate}' WHERE `game`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Delete(int id)
        {
            string sql = $"DELETE FROM `game` WHERE `game`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            Entry.DeleteEntry(id);

            return true;
        }

    }
}
