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

            return $"Host={Host};Username={Username};Password={Password};Database={Database}; Include Error Detail=true";
        }
    }
}
