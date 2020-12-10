using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AzureCosmosDBTesting.Application.DataAccess
{
    public class MongoDatabaseFactory : IMongoDatabaseFactory
    {
        private readonly IMongoClient _mongoClient;
        private readonly IOptions<DatabaseOptions> _options;

        public MongoDatabaseFactory(IMongoClient mongoClient, IOptions<DatabaseOptions> options)
        {
            _mongoClient = mongoClient;
            _options = options;
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string name)
        {
            IMongoDatabase database = _mongoClient.GetDatabase(_options.Value.DatabaseName);
            return database.GetCollection<TDocument>(name);
        }

        public IMongoDatabase GetDatabase()
        {
            return _mongoClient.GetDatabase(_options.Value.DatabaseName);
        }
    }
}
