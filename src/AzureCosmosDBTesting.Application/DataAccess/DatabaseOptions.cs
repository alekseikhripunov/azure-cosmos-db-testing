namespace AzureCosmosDBTesting.Application.DataAccess
{
    public class DatabaseOptions
    {
        public const string Section = "Database";

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}