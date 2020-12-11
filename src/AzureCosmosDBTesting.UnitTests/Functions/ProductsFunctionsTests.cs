using AzureCosmosDBTesting.Application.DataAccess;
using AzureCosmosDBTesting.Application.Functions;
using AzureCosmosDBTesting.Application.Models;
using AzureCosmosDBTesting.UnitTests.Infrastructure;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AzureCosmosDBTesting.UnitTests.Functions
{
    public class ProductsFunctionsTests
    {
        private readonly ProductsFunctions _functions;

        public ProductsFunctionsTests()
        {
            MongoDatabaseContext context = MongoDatabase.GetMongoDatabaseContext();
            _functions = new ProductsFunctions(context);
        }

        [Fact]
        public async Task CreateProductAsync_ProductCreated()
        {
            //Arrange
            await MongoDatabase.RecreateAsync();

            //Act
            await _functions.CreateProductAsync(null);

            //Assert
            MongoDatabaseContext context = MongoDatabase.GetMongoDatabaseContext();
            Product product = await context.Products.AsQueryable().SingleAsync();

            Assert.NotEqual(Guid.NewGuid(), product.Id);
            Assert.Equal("Surface Headphones", product.Name);
            Assert.Equal("Mobile Devices", product.Category);
            Assert.Equal(250, product.Price);
        }
    }
}
