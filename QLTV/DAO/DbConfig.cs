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
            const string Password = "123";
            const string Database = "QLTV";

            return $"Host={Host};Username={Username};Password={Password};Database={Database}; Include Error Detail=true";
        }       
    }
}
