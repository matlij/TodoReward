using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Models.ExternalModels;

namespace TodoReward.WebApi;

public class Function1
{
    private readonly ILogger _logger;
    private readonly IGenericRepository<TodoItem> _itemRepository;

    public Function1(ILoggerFactory loggerFactory, IGenericRepository<TodoItem> itemRepository)
    {
        _logger = loggerFactory.CreateLogger<Function1>();
        _itemRepository = itemRepository;
    }

    [Function("Function1")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var result = await _itemRepository.GetBySpecificationAsync("since=2023-09-03T10:41:15.000000Z");

        HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}
