using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Npgsql;
using System.Data;
namespace QLTV.DAO
{
    class ConnectingDatabase
    {
        private static readonly string _connString;
        public static NpgsqlConnection _conn;
        static ConnectingDatabase(){
             _connString = "Host=localhost:5432;Username=postgres;Password=141517;Database=qltv";
            _conn = new NpgsqlConnection(_connString);
            _conn.Open();
        }

        public static string GetConnString()
        {
            return _connString;
        }
        public static bool NewQuery(string sql)
        {
            
            try
            {
                Debug.WriteLine(sql);
                var da = new NpgsqlCommand(sql, _conn);
                da.ExecuteNonQuery();
            }
            catch (NpgsqlException e)  // CS0168
            {

                // Handle duplicate key error
                Debug.WriteLine(e.Message);
                return false;     
        
            }
            return true;
        }    

        public static DataTable getDataset(string sql)
        {
            var da = new NpgsqlCommand(sql, _conn);
            var ad = new NpgsqlDataAdapter(da);
            var tb = new DataTable();
            ad.Fill(tb);
            return tb;
        }   
    }
}
