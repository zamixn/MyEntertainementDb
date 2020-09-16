using MDB_backend.Tools;
using Newtonsoft.Json;
using System;
using System.Data;

namespace MDB_backend.Models
{
    public abstract class Entry
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public double Rating { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Description { get; private set; }

        protected Entry()
        {
        }

        [JsonConstructor]
        protected Entry(int id, string title, double rating, DateTime releaseDate, string description)
        {
            Id = id;
            Title = title;
            Rating = rating;
            ReleaseDate = releaseDate;
            Description = description;
        }

        public static int GetAutoIncrament()
        {
            string sql = $"SELECT `AUTO_INCREMENT` FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'mdb' AND TABLE_NAME = 'entry'; ";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            var row = dt.Rows[0];
            int ai = Convert.ToInt32(row["AUTO_INCREMENT"]);
            return ai;
        }

        protected bool CreateEntry(int id)
        {
            string sql = $"INSERT INTO `entry`(`Title`, `Rating`, `Description`, `id`) VALUES ('{Title}','{Rating}','{Description}','{id}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        protected bool UpdateEntry(int id)
        {
            string sql = $"UPDATE `entry` SET `Title`='{Title}',`Rating`='{Rating}',`Description`='{Description}' WHERE `entry`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        protected static bool DeleteEntry(int id)
        {
            string sql = $"DELETE FROM `entry` WHERE `entry`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }
    }
}
