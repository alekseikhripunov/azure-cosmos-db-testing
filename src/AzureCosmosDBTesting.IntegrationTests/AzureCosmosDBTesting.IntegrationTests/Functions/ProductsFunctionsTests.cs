using AzureCosmosDBTesting.Application.DataAccess;
using AzureCosmosDBTesting.Application.Functions;
using AzureCosmosDBTesting.Application.Models;
using AzureCosmosDBTesting.IntegrationTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AzureCosmosDBTesting.IntegrationTests.Functions
{
    public class ProductsFunctionsTests : IClassFixture<IntegrationFixture>
    {
        private readonly ProductsFunctions _functions;
        private readonly MongoDatabaseContext _context;

        public ProductsFunctionsTests(IntegrationFixture fixture)
        {
            _context = fixture.Services.GetRequiredService<MongoDatabaseContext>();
            _functions = new ProductsFunctions(_context);
        }

        [Fact]
        public async Task CreateProductAsync_ProductCreated()
        {
            //Assert
            await MongoDatabase.RecreateAsync();

            //Act
            await _functions.CreateProductAsync(null);

            //Assert
            List<Product> products = await _context.Products.AsQueryable().ToListAsync();
            Assert.Single(products);

            Assert.NotEqual(Guid.Empty, products[0].Id);
            Assert.Equal("Surface Headphones", products[0].Name);
            Assert.Equal("Mobile Devices", products[0].Category);
            Assert.Equal(250, products[0].Price);
        }
    }
}
