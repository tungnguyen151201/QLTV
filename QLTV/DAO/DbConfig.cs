using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace QLTV.DAO
{   
    public class DbConfig
    {
        public static string Config()
        {
            const string Host = "localhost:5432";
            const string Username = "postgres";
            const string Password = "141517";
            const string Database = "qltv";

            return $"Host={Host};Username={Username};Password={Password};Database={Database}";
        }       
    }
}
