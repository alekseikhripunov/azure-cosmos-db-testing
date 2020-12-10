using AzureCosmosDBTesting.Application;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace AzureCosmosDBTesting.IntegrationTests.Infrastructure
{
    public class IntegrationFixture
    {
        public IntegrationFixture()
        {
            Environment.SetEnvironmentVariable("Database:ConnectionString", MongoDatabase.ConnectionString, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("Database:DatabaseName", MongoDatabase.DatabaseName, EnvironmentVariableTarget.Process);

            Host = new HostBuilder()
                .ConfigureWebJobs(b => b.UseWebJobsStartup(typeof(Startup), new WebJobsBuilderContext(), NullLoggerFactory.Instance))
                .Build();
        }

        private IHost Host { get; }

        public IServiceProvider Services => Host.Services;
    }
}
