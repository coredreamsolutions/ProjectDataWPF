using System;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace ProjectDataWPF.Services
{
    public class Database
    {
        private static string _ConnectionString = null;
        public static string ConnectionString
        {
            get
            {
                if (_ConnectionString == null)
                    _ConnectionString = ConfigurationManager.ConnectionStrings["ComtrexDefinitions"].ConnectionString;

                return _ConnectionString;
            }
        }

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(ConnectionString);
        }

        public static DataTable Select(string sql, params OleDbParameter[] param)
        {
            using (var cnn = Database.GetConnection())
            using (OleDbCommand cmd = new OleDbCommand(sql, cnn))
            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(param);
                cnn.Open();

                DataTable data = new DataTable("data");
                adp.Fill(data);
                return data;
            }
        }

        public static DataSet SelectTwo(string sql, params OleDbParameter[] param)
        {
            using (var cnn = Database.GetConnection())
            using (OleDbCommand cmd = new OleDbCommand(sql, cnn))
            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(param);
                cnn.Open();

                DataSet data = new DataSet("data");
                adp.Fill(data);
                return data;
            }
        }
    }
}
