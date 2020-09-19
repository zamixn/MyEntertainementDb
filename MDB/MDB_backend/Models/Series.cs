using MDB_backend.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Series : WatchableEntry
    {
        public int EpisodesSeen;
        public int EpisodeCount;
        public DateTime ReleaseDate;
        public DateTime FinishDate;

        public Series() : base()
        {
        }

        [JsonConstructor]
        public Series(int episodesSeen, int episodeCount, DateTime releaseDate, DateTime finishDate,
            int id, string title, double myRating, string description, int timesSeen, DateTime lastSeen)
            : base(id, title, myRating, description, timesSeen, lastSeen)
        {
            EpisodesSeen = episodesSeen;
            EpisodeCount = episodeCount;
            ReleaseDate = releaseDate;
            FinishDate = finishDate;
        }


        public static List<Series> GetSeries()
        {
            string sql = $"SELECT * FROM `series` LEFT JOIN `watchableentry` ON `series`.`id`= `watchableentry`.`id` LEFT JOIN `entry` ON `series`.`id`=`entry`.`id`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<Series> list = new List<Series>();
            foreach (DataRow row in dt.Rows)
            {
                Series series = new Series(
                    id: Convert.ToInt32(row["id"]),
                    title: Convert.ToString(row["Title"]),
                    myRating: Convert.ToDouble(row["Rating"]),
                    releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                    description: Convert.ToString(row["Description"]),
                    timesSeen: Convert.ToInt32(row["TimesSeen"]),
                    lastSeen: Convert.ToDateTime(row["LastSeen"]),
                    episodesSeen: Convert.ToInt32(row["EpisodesSeen"]),
                    episodeCount: Convert.ToInt32(row["EpisodeCount"]),
                    finishDate: Convert.ToDateTime(row["FinishDate"])
                    );
                list.Add(series);
            }
            return list;
        }

        public static Series GetSeries(int id)
        {
            string sql = $"SELECT * FROM `series` LEFT JOIN `watchableentry` ON `series`.`id`= `watchableentry`.`id` LEFT JOIN `entry` ON `series`.`id`=`entry`.`id` WHERE `series`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            var row = dt.Rows[0];
            return new Series(
                    id: Convert.ToInt32(row["id"]),
                    title: Convert.ToString(row["Title"]),
                    myRating: Convert.ToDouble(row["Rating"]),
                    releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                    description: Convert.ToString(row["Description"]),
                    timesSeen: Convert.ToInt32(row["TimesSeen"]),
                    lastSeen: Convert.ToDateTime(row["LastSeen"]),
                    episodesSeen: Convert.ToInt32(row["EpisodesSeen"]),
                    episodeCount: Convert.ToInt32(row["EpisodeCount"]),
                    finishDate: Convert.ToDateTime(row["FinishDate"])
                    );
        }

        public static Series Create(Series s)
        {
            int id = Entry.GetAutoIncrament();
            s.ChangeId(id);

            s.CreateWatchableEntry(id);

            string sql = $"INSERT INTO `series`(`EpisodesSeen`, `EpisodeCount`, `ReleaseDate`, `FinishDate`, `id`) VALUES ('{s.EpisodesSeen}','{s.EpisodeCount}','{s.ReleaseDate}','{s.FinishDate}','{id}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            return s;
        }

        public static bool Update(int id, Series s)
        {
            s.UpdateWatchableEntry(id);

            string sql = $"UPDATE `series` SET `EpisodesSeen`='{s.EpisodesSeen}',`EpisodeCount`='{s.EpisodeCount}',`ReleaseDate`='{s.ReleaseDate}',`FinishDate`='{s.FinishDate}' WHERE `series`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Delete(int id)
        {
            string sql = $"DELETE FROM `series` WHERE `series`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            WatchableEntry.DeleteWatchableEntry(id);

            return true;
        }


    }
}
