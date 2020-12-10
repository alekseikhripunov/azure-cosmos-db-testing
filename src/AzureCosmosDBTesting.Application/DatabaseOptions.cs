namespace AzureCosmosDBTesting.Application
{
    public class DatabaseOptions
    {
        public const string Section = "Database";

        public string ConnetionString { get; set; }

        public string DatabaseName { get; set; }
    }
}