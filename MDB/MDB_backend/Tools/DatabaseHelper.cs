using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Tools
{
    public static class DatabaseHelper
    {

        public static void ExecuteNonQuery(string sqlQuery)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            MySqlCommand mySqlCommand = new MySqlCommand(sqlQuery, mySqlConnection);
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public static DataTable FillDataTableWithQueryResults(string sqlQuery)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            MySqlCommand mySqlCommand = new MySqlCommand(sqlQuery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            mda.Dispose();

            return dt;
        }

        public static bool CheckIfRowExists(string tableName, int id, string columnName = "id")
        {
            string sql = $"SELECT COUNT(1) as 'found' FROM `{tableName}` WHERE `{columnName}` = '{id}'";
            DataTable dt = FillDataTableWithQueryResults(sql);
            var row = dt.Rows[0];
            return Convert.ToInt32(row["found"]) > 0;
        }



        public static int GetTableAutoIncrament(string tableName)
        {
            string sql = $"SELECT `AUTO_INCREMENT` FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{Startup.dbName}' AND TABLE_NAME = '{tableName}'; ";
            DataTable dt = FillDataTableWithQueryResults(sql);

            var row = dt.Rows[0];
            int ai = Convert.ToInt32(row["AUTO_INCREMENT"]);
            return ai;
        }
    }
}
