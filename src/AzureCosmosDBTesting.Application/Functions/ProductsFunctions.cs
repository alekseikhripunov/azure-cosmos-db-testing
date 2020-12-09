using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;

namespace AzureCosmosDBTesting.Application.Functions
{
    public static class ProductsFunctions
    {
        [FunctionName("GetAllProducts")]
        public static void GetAllProducts([HttpTrigger("get", Route = "products/all")] HttpRequest request)
        {

        }
    }
}
