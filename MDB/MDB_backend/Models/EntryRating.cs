using MDB_backend.Tools;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class EntryRating
    {

        public double Rating { get; private set; }
        public int id { get; private set; }
        public int entry_id { get; private set; }
        public int user_id { get; private set; }

        public EntryRating(double rating, int id, int entry_id, int user_id)
        {
            Rating = rating;
            this.id = id;
            this.entry_id = entry_id;
            this.user_id = user_id;
        }

        public List<EntryRating> GetUserRated(SystemUser user)
        {
            string sql = $"SELECT * FROM `entryrating` WHERE `fk_Userid`='{user.id}'";
            DataTable dt = DatabaseHelper.FillDataTableWithQueryResults(sql);

            List<EntryRating> list = new List<EntryRating>();
            foreach (DataRow row in dt.Rows)
                list.Add(ParseEntryRating(row));
            return list;


        }

        public static EntryRating ParseEntryRating(DataRow row)
        {
            return new EntryRating(rating: Convert.ToDouble(row["Rating"]),
                                   id: Convert.ToInt32(row["id_EntryRating"]),
                                   entry_id: Convert.ToInt32(row["fk_Entryid"]),
                                   user_id: Convert.ToInt32(row["fk_Userid"]));
        }


        public static bool Create(EntryRating entryRating)
        {
            int id = DatabaseHelper.GetTableAutoIncrament("entryrating");
            entryRating.id = id;
            string sql = $"INSERT INTO `entryrating`(`Rating`, `fk_Entryid`, `fk_Userid`) VALUES ('{entryRating.Rating}','{entryRating.entry_id}','{entryRating.user_id}')";
            DatabaseHelper.ExecuteNonQuery(sql);
            return true;
        }
    }
}
