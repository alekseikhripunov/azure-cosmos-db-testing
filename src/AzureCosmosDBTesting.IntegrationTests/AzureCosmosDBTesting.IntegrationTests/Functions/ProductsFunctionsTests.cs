﻿using AzureCosmosDBTesting.Application.DataAccess;
using AzureCosmosDBTesting.Application.Functions;
using AzureCosmosDBTesting.Application.Models;
using AzureCosmosDBTesting.IntegrationTests.Infrastructure;
using AzureCosmosDBTesting.UnitTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AzureCosmosDBTesting.IntegrationTests.Functions
{
    public class ProductsFunctionsTests : IClassFixture<IntegrationFixture>
    {
        private readonly ProductsFunctions _functions;

        public ProductsFunctionsTests(IntegrationFixture fixture)
        {
            MongoDatabaseContext context = fixture.Services.GetRequiredService<MongoDatabaseContext>();
            _functions = new ProductsFunctions(context);
        }

        [Fact]
        public async Task CreateProductAsync_ProductCreated()
        {
            //Assert
            await MongoDatabase.RecreateAsync();

            //Act
            await _functions.CreateProductAsync(null);

            //Assert
            MongoDatabaseContext context = MongoDatabase.GetMongoDatabaseContext();
            Product product = await context.Products.AsQueryable().SingleAsync();

            Assert.NotEqual(Guid.Empty, product.Id);
            Assert.Equal("Surface Headphones", product.Name);
            Assert.Equal("Mobile Devices", product.Category);
            Assert.Equal(250, product.Price);
        }
    }
}
