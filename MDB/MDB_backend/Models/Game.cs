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
        public DateTime ReleaseDate { get; private set; }

        public Game() : base()
        {
        }

        [JsonConstructor]
        public Game(int id, string title, string description, int creator, DateTime releaseDate, string poster)
            : base(id, title, description, creator, poster)
        {
            ReleaseDate = releaseDate;
        }


        public static List<Game> GetList()
        {
            string sql = $"SELECT * FROM `game` LEFT JOIN `entry` ON `game`.`id`=`entry`.`id`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<Game> list = new List<Game>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Parse(row));
            }
            return list;
        }

        public static Game Get(int id)
        {
            string sql = $"SELECT * FROM `game` LEFT JOIN `entry` ON `game`.`id`=`entry`.`id` WHERE `game`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            if (dt.Rows.Count <= 0)
                return null;
            var row = dt.Rows[0];
            return Parse(row);

        }

        public static Game Parse(DataRow row)
        { 
            return new Game(
                   id: Convert.ToInt32(row["id"]),
                   title: Convert.ToString(row["Title"]),
                   releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                   description: Convert.ToString(row["Description"]),
                   creator: Convert.ToInt32(row["fk_user_creator"]),
                   poster: Convert.ToString(row["Poster"])
                   );
        }

        public static bool Create(Game g)
        {
            int id = Entry.GetAutoIncrament(); 
            g.CreateEntry(id);

            string sql = $"INSERT INTO `game`(`id`, `ReleaseDate`) VALUES ('{id}','{g.ReleaseDate}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            g.ChangeId(id);

            return true;
        }

        public static bool Update(int id, Game g)
        {
            if (!DatabaseHelper.CheckIfRowExists("game", id))
                return false;

            g.UpdateEntry(id);

            string sql = $"UPDATE `game` SET `ReleaseDate`='{g.ReleaseDate}' WHERE `game`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Delete(int id)
        {
            if (!DatabaseHelper.CheckIfRowExists("game", id))
                return false;

            string sql = $"DELETE FROM `game` WHERE `game`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            Entry.DeleteEntry(id);

            return true;
        }

        public static bool IdExists(int id)
        {
            return DatabaseHelper.CheckIfRowExists("game", id);
        }
    }
}
