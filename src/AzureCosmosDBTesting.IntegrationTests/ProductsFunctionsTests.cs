﻿using MongoDB.Driver;
using NUnit.Framework;

namespace AzureCosmosDBTesting.IntegrationTests
{
    public class ProductsFunctionsTests
    {
        [Test]
        public void Test()
        {
            var mongoClient = new MongoClient();
            IMongoDatabase database = mongoClient.GetDatabase("");
        }
    }
}