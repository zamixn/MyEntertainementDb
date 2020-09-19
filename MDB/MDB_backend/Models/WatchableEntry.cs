using MDB_backend.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class WatchableEntry : Entry
    {
        public int TimesSeen { get; private set; }
        public DateTime LastSeen { get; private set; }

        public WatchableEntry() : base()
        {
        }

        [JsonConstructor]
        public WatchableEntry(int id, string title, double myRating, string description, int timesSeen, DateTime lastSeen)
            : base(id, title, myRating, description)
        {
            TimesSeen = timesSeen;
            LastSeen = lastSeen;
        }

        protected bool CreateWatchableEntry(int id)
        {
            CreateEntry(id);

            string sql = $"INSERT INTO `watchableentry`(`TimesSeen`, `LastSeen`, `id`) VALUES ('{TimesSeen}','{LastSeen}','{id}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        protected bool UpdateWatchableEntry(int id)
        {
            UpdateEntry(id);

            string sql = $"UPDATE `watchableentry` SET `TimesSeen`='{TimesSeen}',`LastSeen`='{LastSeen}' WHERE `watchableentry`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        protected static bool DeleteWatchableEntry(int id)
        {
            string sql = $"DELETE FROM `watchableentry` WHERE `watchableentry`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            Entry.DeleteEntry(id);

            return true;
        }
    }
}
