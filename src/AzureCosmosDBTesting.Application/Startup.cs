using AzureCosmosDBTesting.Application;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureCosmosDBTesting.Application
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IMongoClient, MongoClient>(p =>
            {
                var configuration = p.GetRequiredService<IConfiguration>();

                return new MongoClient(configuration["Database:ConnectionString"]);
            });
        }
    }
}
