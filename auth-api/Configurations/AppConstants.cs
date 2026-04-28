namespace auth_api.Configurations;

public static class AppConstants
{
    public static class ConnectionStrings
    {
        public const string SECTION_NAME = "ConnectionStrings";
        public const string SQL_SERVER_CONNECTION = "SqlServerConnection";
        public const string MY_SQL_CONNECTION = "MySqlConnection";
        public const string DB_PROVIDER = "DbProvider";
    }

    public static class DbProviders
    {
        public const string SQL_SERVER = "SqlServer";
        public const string MY_SQL = "MySql";
    }
}
