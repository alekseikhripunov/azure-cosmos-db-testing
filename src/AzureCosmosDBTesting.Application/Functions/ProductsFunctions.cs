using AzureCosmosDBTesting.Application.DataAccess;
using AzureCosmosDBTesting.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace AzureCosmosDBTesting.Application.Functions
{
    public class ProductsFunctions
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabaseFactory _mongoDatabaseFactory;

        public ProductsFunctions(IMongoClient mongoClient, IMongoDatabaseFactory mongoDatabaseFactory)
        {
            _mongoClient = mongoClient;
            _mongoDatabaseFactory = mongoDatabaseFactory;
        }

        [FunctionName("GetAllProducts")]
        public async Task GetAllProductsAsync([HttpTrigger("get", Route = "products/all")] HttpRequest request)
        {
            IMongoCollection<Product> collection = _mongoDatabaseFactory.GetCollection<Product>("Products");

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Surface Headphones",
                Category = "Mobile Devices",
                Price = 250
            };
            await collection.InsertOneAsync(product);
        }
    }
}
