using MongoDB.Driver;

namespace AzureCosmosDBTesting.Application.DataAccess
{
    public interface IMongoDatabaseFactory
    {
        IMongoCollection<TDocument> GetCollection<TDocument>(string name);
    }
}
