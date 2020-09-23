using MDB_backend.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models.ExternalSources
{
    public class Creator
    {
        public enum CreatorType
        {
            Developer,
            Publisher,
            Director            
        }

        public string Name { get; private set; }
        public string Info { get; private set; }
        public CreatorType Type { get; private set; }
        public int id { get; private set; }

        public Creator(string name, string info, CreatorType type, int id)
        {
            Name = name;
            Info = info;
            Type = type;
            this.id = id;
        }

        public static List<Creator> GetList()
        {
            string sql = $"SELECT * FROM `creator`";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<Creator> list = new List<Creator>();
            foreach (DataRow row in dt.Rows)
            {
                Creator game = new Creator(
                    id: Convert.ToInt32(row["id"]),
                    info: Convert.ToString(row["Info"]),
                    type: (CreatorType)Convert.ToInt32(row["CreatorType"]),
                    name: Convert.ToString(row["Name"])
                    );
                list.Add(game);
            }
            return list;
        }

        public static Creator Get(int id)
        {
            string sql = $"SELECT * FROM `creator` WHERE `creator`.`id`='{id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            if (dt.Rows.Count <= 0)
                return null;
            var row = dt.Rows[0];
            return new Creator(
                    id: Convert.ToInt32(row["id"]),
                    info: Convert.ToString(row["Info"]),
                    type: (CreatorType)Convert.ToInt32(row["CreatorType"]),
                    name: Convert.ToString(row["Name"])
                    );

        }

        public static bool Create(Creator c)
        {
            string sql = $"INSERT INTO `creator`(`Name`, `Info`, `CreatorType`) VALUES ('{c.Name}','{c.Info}','{(int)c.Type}')";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Update(int id, Creator c)
        {
            if (!DatabaseHelper.CheckIfRowExists("creator", id))
                return false;

            string sql = $"UPDATE `creator` SET `Name`='{c.Name}',`Info`='{c.Info}',`CreatorType`='{(int)c.Type}' WHERE `creator`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }

        public static bool Delete(int id)
        {
            if (!DatabaseHelper.CheckIfRowExists("creator", id))
                return false;

            string sql = $"DELETE FROM `creator` WHERE `creator`.`id`='{id}'";
            DatabaseHelper.ExecuteNonQuery(sql);

            return true;
        }
    }
}
