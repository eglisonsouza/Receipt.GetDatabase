using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Receipt.GetDatabase.Models;

namespace Receipt.GetDatabase
{
    public class GetAllProductsFunction
    {
        private const string Query = "SELECT * FROM c";
        private readonly ILogger<GetAllProductsFunction> _logger;
        private readonly CosmosClient _client;
        private readonly string _databaseId;
        private readonly string _containerId;

        public GetAllProductsFunction(ILogger<GetAllProductsFunction> logger, CosmosClient client)
        {
            _logger = logger;
            _client = client;
            _databaseId = Environment.GetEnvironmentVariable("DatabaseId") ?? string.Empty;
            _containerId = Environment.GetEnvironmentVariable("ContainerId") ?? string.Empty;
        }

        [Function("GetAllProducts")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("HTTP trigger function processed a request.");

            var container = _client.GetContainer(_databaseId, _containerId);

            var query = new QueryDefinition(Query);

            var result = container.GetItemQueryIterator<Product>(query);

            var results = new List<Product>();

            while (result.HasMoreResults)
            {
                var response = await result.ReadNextAsync();
                foreach (var item in response)
                {
                    results.Add(item);
                }
            }

            return new OkObjectResult(results);
        }
    }
}
