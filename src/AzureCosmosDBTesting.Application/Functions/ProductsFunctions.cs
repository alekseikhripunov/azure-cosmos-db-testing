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
        private readonly MongoDatabaseContext _mongoDatabaseContext;

        public ProductsFunctions(MongoDatabaseContext mongoDatabaseContext)
        {
            _mongoDatabaseContext = mongoDatabaseContext;
        }

        [FunctionName("CreateProduct")]
        public async Task CreateProductAsync([HttpTrigger("post", Route = "products")] HttpRequest request)
        {
            IMongoCollection<Product> products = _mongoDatabaseContext.Products;

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Surface Headphones",
                Category = "Mobile Devices",
                Price = 250
            };
            await products.InsertOneAsync(product);
        }
    }
}
