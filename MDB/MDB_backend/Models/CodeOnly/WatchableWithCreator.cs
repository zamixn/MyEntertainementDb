using MDB_backend.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.CodeOnly
{
    public class WatchableWithCreator
    {
        public Watchable watchable;
        public Creator creator;

        public static WatchableWithCreator Parse(DataRow row)
        {
            return new WatchableWithCreator()
            {
                watchable = Watchable.Parse(row),
                creator = Creator.Parse(row)
            };
        }

        public static IEnumerable<WatchableWithCreator> GetList()
        {
            string sql = $"SELECT * FROM `watchable` LEFT JOIN `entry` ON `watchable`.`id`=`entry`.`id` LEFT JOIN `creator` ON `creator`.`creator_id`=`entry`.`fk_user_creator`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<WatchableWithCreator> list = new List<WatchableWithCreator>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Parse(row));
            }
            return list;
        }

        public static WatchableWithCreator Get(int id)
        {
            string sql = $"SELECT * FROM `watchable` LEFT JOIN `entry` ON `watchable`.`id`=`entry`.`id` LEFT JOIN `creator` ON `creator`.`creator_id`=`entry`.`fk_user_creator` WHERE `watchable`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            if (dt.Rows.Count <= 0)
                return null;
            var row = dt.Rows[0];
            return Parse(row);
        }
    }
}
