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
        public string Description { get; private set; }
        public int Creator { get; private set; }
        public string Poster { get; private set; }

        protected Entry()
        {
        }

        [JsonConstructor]
        protected Entry(int id, string title, string description, int creator, string poster)
        {
            Id = id;
            Title = title;
            Description = description;
            Creator = creator;
            Poster = poster;
        }

        public void ChangeId(int newId)
        {
            Id = newId;
        }

        public static int GetAutoIncrament()
        {
            string sql = $"SELECT `AUTO_INCREMENT` FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{Startup.dbName}' AND TABLE_NAME = 'entry'; ";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            var row = dt.Rows[0];
            int ai = Convert.ToInt32(row["AUTO_INCREMENT"]);
            return ai;
        }

        protected bool CreateEntry(int id)
        {
            string sql = $"INSERT INTO `entry`(`Title`, `Description`, `fk_Userid`, `id`, `Poster`) VALUES ('{Title}','{Description}', '{Creator}','{id}', '{Poster}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        protected bool UpdateEntry(int id)
        {
            string sql = $"UPDATE `entry` SET `Title`='{Title}',`Description`='{Description}',`fk_Userid`='{Creator}',`Poster`='{Poster}' WHERE `entry`.`id`='{id}'";
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
