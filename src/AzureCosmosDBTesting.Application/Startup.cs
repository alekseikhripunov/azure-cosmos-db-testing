using AzureCosmosDBTesting.Application;
using AzureCosmosDBTesting.Application.DataAccess;
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
            builder.Services
                .AddOptions<DatabaseOptions>()
                .Configure<IConfiguration>((o, c) =>
                {
                    c.GetSection(DatabaseOptions.Section).Bind(o);
                });

            builder.Services.AddSingleton<IMongoDatabaseFactory, MongoDatabaseFactory>();
            builder.Services.AddSingleton<IMongoClient, MongoClient>(p =>
            {
                IConfiguration configuration = p.GetRequiredService<IConfiguration>();

                return new MongoClient(configuration["Database:ConnectionString"]);
            });
        }
    }
}
