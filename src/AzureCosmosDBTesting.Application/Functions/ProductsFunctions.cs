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

        public ProductsFunctions(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        [FunctionName("GetAllProducts")]
        public async Task GetAllProductsAsync([HttpTrigger("get", Route = "products/all")] HttpRequest request)
        {
            IMongoDatabase database = _mongoClient.GetDatabase("AzureCosmosDBTesting");
            IMongoCollection<Product> collection = database.GetCollection<Product>("Products");

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
