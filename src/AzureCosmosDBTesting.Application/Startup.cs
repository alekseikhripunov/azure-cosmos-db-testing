using AzureCosmosDBTesting.Application.DataAccess;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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

            builder.Services.AddSingleton<MongoDatabaseContext>();
            builder.Services.AddSingleton<IMongoClient, MongoClient>(p =>
            {
                IOptions<DatabaseOptions> options = p.GetRequiredService<IOptions<DatabaseOptions>>();
                return new MongoClient(options.Value.ConnectionString);
            });
        }
    }
}
