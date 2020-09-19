using MDB_backend.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Movie : WatchableEntry
    {
        public DateTime ReleaseDate { get; private set; }

        public Movie() : base()
        {
        }

        [JsonConstructor]
        public Movie(int id, string title, double myRating, string description, DateTime releaseDate, int timesSeen, DateTime lastSeen)
            : base(id, title, myRating, description, timesSeen, lastSeen)
        {
            ReleaseDate = releaseDate;
        }

        public static List<Movie> GetMovies()
        {
            string sql = $"SELECT * FROM `movie` LEFT JOIN `watchableentry` ON `movie`.`id`= `watchableentry`.`id` LEFT JOIN `entry` ON `movie`.`id`=`entry`.`id`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<Movie> list = new List<Movie>();
            foreach (DataRow row in dt.Rows)
            {
                Movie movie = new Movie(
                    id: Convert.ToInt32(row["id"]),
                    title: Convert.ToString(row["Title"]),
                    myRating: Convert.ToDouble(row["Rating"]),
                    releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                    description: Convert.ToString(row["Description"]),
                    timesSeen: Convert.ToInt32(row["TimesSeen"]),
                    lastSeen: Convert.ToDateTime(row["LastSeen"])
                    );
                list.Add(movie);
            }
            return list;
        }

        public static Movie GetMovie(int id)
        {
            string sql = $"SELECT * FROM `movie` LEFT JOIN `watchableentry` ON `movie`.`id`= `watchableentry`.`id` LEFT JOIN `entry` ON `movie`.`id`=`entry`.`id` WHERE `movie`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            var row = dt.Rows[0];
            return new Movie(
                    id: Convert.ToInt32(row["id"]),
                    title: Convert.ToString(row["Title"]),
                    myRating: Convert.ToDouble(row["Rating"]),
                    releaseDate: Convert.ToDateTime(row["ReleaseDate"]),
                    description: Convert.ToString(row["Description"]),
                    timesSeen: Convert.ToInt32(row["TimesSeen"]),
                    lastSeen: Convert.ToDateTime(row["LastSeen"])
                    );
        }

        public static Movie Create(Movie m)
        {
            int id = Entry.GetAutoIncrament();
            m.ChangeId(id);

            m.CreateWatchableEntry(id);

            string sql = $"INSERT INTO `movie`(`ReleaseDate`, `id`) VALUES ('{m.ReleaseDate}','{id}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            return m;
        }

        public static bool Update(int id, Movie m)
        {
            m.UpdateWatchableEntry(id);

            string sql = $"UPDATE `movie` SET `ReleaseDate`='{m.ReleaseDate}' WHERE `movie`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Delete(int id)
        {
            string sql = $"DELETE FROM `movie` WHERE `movie`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            WatchableEntry.DeleteWatchableEntry(id);

            return true;
        }


    }
}
