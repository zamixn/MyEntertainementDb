using MDB_backend.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.CodeOnly
{
    public class GameWithCreator
    {
        public Game game;
        public Creator creator;

        public static GameWithCreator Parse(DataRow row)
        {
            return new GameWithCreator()
            {
                game = Game.Parse(row),
                creator = Creator.Parse(row)
            };
        }


        public static List<GameWithCreator> GetList()
        {
            string sql = $"SELECT * FROM `game` LEFT JOIN `entry` ON `game`.`id`=`entry`.`id` LEFT JOIN `creator` ON `creator`.`creator_id`=`entry`.`fk_user_creator`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<GameWithCreator> list = new List<GameWithCreator>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Parse(row));
            }
            return list;
        }

        public static GameWithCreator Get(int id)
        {
            string sql = $"SELECT * FROM `game` LEFT JOIN `entry` ON `game`.`id`=`entry`.`id` LEFT JOIN `creator` ON `creator`.`creator_id`=`entry`.`fk_user_creator` WHERE `game`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            if (dt.Rows.Count <= 0)
                return null;
            var row = dt.Rows[0];
            return Parse(row);

        }
    }
}
