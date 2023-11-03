using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Core.Models.Constants;
using TodoReward.Infrastructure.Models.ExternalModels;

namespace TodoReward.WebApi;

public class TodoRewardFunction
{
    private readonly ILogger _logger;
    private readonly IGenericRepository<TodoItem> _itemRepository;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;

    public TodoRewardFunction(ILoggerFactory loggerFactory, IGenericRepository<TodoItem> itemRepository, IGenericRepository<User> userRepository, IRewardService rewardService, IMapper mapper)
    {
        _logger = loggerFactory.CreateLogger<TodoRewardFunction>();
        _itemRepository = itemRepository;
        _userRepository = userRepository;
        _rewardService = rewardService;
        _mapper = mapper;
    }

    [Function("Auth")]
    public async Task<HttpResponseData> Auth([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        var requestBody = await req.ReadAsStringAsync();
        _logger.LogInformation("C# HTTP trigger function processed a request. Body: " + requestBody);

        return req.CreateResponse(HttpStatusCode.OK);
    }

    [Function("TodoComplete")]
    public async Task<HttpResponseData> CompleteTodo([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        var requestBody = await req.ReadFromJsonAsync<TodoistPushNotification>();
        if (requestBody == null)
        {
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        if (!requestBody.event_name.Equals("item:completed", StringComparison.OrdinalIgnoreCase))
        {
            return req.CreateResponse(HttpStatusCode.OK);
        }

        var todoItem = _mapper.Map<TodoItem>(requestBody.event_data);

        await _rewardService.RegisterRewardOnUserAsync(todoItem, ModelConstants.UserId);

        return req.CreateResponse(HttpStatusCode.OK);
    }

    [Function("SyncCompletedItems")]
    public async Task<HttpResponseData> SyncCompletedItems([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var user = await _userRepository.GetByIdAsync(ModelConstants.UserId);
        if (user == null)
        {
            _logger.LogError("Couldn't find user with ID: " + ModelConstants.UserId);
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }

        var getLastCompletedItem = user?.LastCompletedItem?.CompletedDate ?? DateTime.MinValue;
        var result = await _itemRepository.GetBySpecificationAsync($"since={getLastCompletedItem}");

        await _rewardService.RegisterRewardsOnUserAsync(result, ModelConstants.UserId);

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}