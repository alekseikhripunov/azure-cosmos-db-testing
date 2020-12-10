using AzureCosmosDBTesting.Application.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AzureCosmosDBTesting.Application.DataAccess
{
    public class MongoDatabaseContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDatabaseContext(IMongoClient mongoClient, IOptions<DatabaseOptions> options)
        {
            _mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Product> Products => GetCollection<Product>("Products");

        public IMongoCollection<TDocument> GetCollection<TDocument>(string name)
        {
            return _mongoDatabase.GetCollection<TDocument>(name);
        }
    }
}
