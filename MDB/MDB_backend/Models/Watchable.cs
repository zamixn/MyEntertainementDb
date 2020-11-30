using MDB_backend.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Watchable : Entry
    {
        public enum WatchableType
        {
            Movie = 1,
            TvSeries = 2,
            Anime = 3
        }

        public WatchableType Type { get; private set; }
        public DateTime ReleaseDate { get; private set; }

        public Watchable() : base()
        {
        }

        [JsonConstructor]
        public Watchable(int id, string title, string description, int creator, WatchableType type, DateTime releaseDate, string poster)
            : base(id, title, description, creator, poster)
        {
            Type = type;
            ReleaseDate = releaseDate;
        }

        public static IEnumerable<Watchable> GetList()
        {
            string sql = $"SELECT * FROM `watchable` LEFT JOIN `entry` ON `watchable`.`id`=`entry`.`id`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<Watchable> list = new List<Watchable>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Parse(row));
            }
            return list;
        }

        public static Watchable Get(int id)
        {
            string sql = $"SELECT * FROM `watchable` LEFT JOIN `entry` ON `watchable`.`id`=`entry`.`id` WHERE `watchable`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            if (dt.Rows.Count <= 0)
                return null;
            var row = dt.Rows[0];
            return Parse(row);
        }

        public static Watchable Parse(DataRow row)
        { 
            return new Watchable(
                   id: Convert.ToInt32(row["id"]),
                   title: Convert.ToString(row["Title"]),
                   description: Convert.ToString(row["Description"]),
                   type: (WatchableType)Convert.ToInt32(row["Type"]),
                   releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                   creator: Convert.ToInt32(row["fk_user_creator"]),
                   poster: Convert.ToString(row["Poster"])
                   );
        }

        public static Watchable Create(Watchable w)
        {
            int id = Entry.GetAutoIncrament();
            w.CreateEntry(id);

            string sql = $"INSERT INTO `watchable`(`Type`, `ReleaseDate`, `id`) VALUES ('{(int)w.Type}', '{w.ReleaseDate}','{id}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            w.ChangeId(id);

            return w;
        }

        public static bool Update(int id, Watchable w)
        {
            if (!DatabaseHelper.CheckIfRowExists("watchable", id))
                return false;

            w.UpdateEntry(id);

            string sql = $"UPDATE `watchable` SET `Type`='{(int)w.Type}',`ReleaseDate`='{w.ReleaseDate}' WHERE `watchable`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Delete(int id)
        {
            if (!DatabaseHelper.CheckIfRowExists("watchable", id))
                return false;

            string sql = $"DELETE FROM `watchable` WHERE `watchable`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            Entry.DeleteEntry(id);

            return true;
        }
    }
}
