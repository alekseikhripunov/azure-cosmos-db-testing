﻿using MongoDB.Driver;
using System.Threading.Tasks;

namespace AzureCosmosDBTesting.IntegrationTests.Infrastructure
{
    public class MongoDatabase
    {
        public const string ConnectionString = "mongodb://localhost:C2y6yDjf5%2FR%2Bob0N8A7Cgv30VRDJIWEHLM%2B4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw%2FJw%3D%3D@localhost:10255/admin?ssl=true";

        public const string DatabaseName = "AzureCosmosDBTesting_Integration";

        public static async Task RecreateAsync()
        {
            var mongoClient = new MongoClient(ConnectionString);
            await mongoClient.DropDatabaseAsync(DatabaseName);
        }
    }
}
