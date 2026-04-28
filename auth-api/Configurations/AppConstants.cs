namespace auth_api.Configurations;

public static class AppConstants
{
    public static class ConnectionStrings
    {
        public const string SectionName = "ConnectionStrings";
        public const string DefaultConnection = "DefaultConnection";
        public const string DbProvider = "DbProvider";
    }

    public static class DbProviders
    {
        public const string SqlServer = "SqlServer";
        public const string MySql = "MySql";
    }
}
