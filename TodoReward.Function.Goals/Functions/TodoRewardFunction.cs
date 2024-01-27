using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Core.Models.Constants;
using TodoReward.Infrastructure.Models.ExternalModels;

namespace TodoReward.Functions.Functions;

public class TodoRewardFunction
{
    private readonly ILogger _logger;
    private readonly IGenericRepository<TodoItem> _itemRepository;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IRewardService _rewardService;
    private readonly IMapper _mapper;

    public TodoRewardFunction(ILoggerFactory loggerFactory,
        IGenericRepository<TodoItem> itemRepository,
        IGenericRepository<User> userRepository,
        IRewardService rewardService,
        IMapper mapper)
    {
        _logger = loggerFactory.CreateLogger<TodoRewardFunction>();
        _itemRepository = itemRepository;
        _userRepository = userRepository;
        _rewardService = rewardService;
        _mapper = mapper;
    }

    [Function("CompleteTodo")]
    public async Task<HttpResponseData> CompleteTodo([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        var requestBody = await req.ReadFromJsonAsync<TodoistPushNotification>();
        if (requestBody == null)
        {
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        if (!requestBody.EventName.Equals("item:completed", StringComparison.OrdinalIgnoreCase) ||
            requestBody.EventData.ProjectId == ExternalTodoConstants.REWARDS_PROJECT_ID)
        {
            return req.CreateResponse(HttpStatusCode.OK);
        }
        var todoItem = _mapper.Map<TodoItem>(requestBody.EventData);

        var reward = await _rewardService.RegisterRewardOnUserAsync(todoItem, ModelConstants.USER_ID);

        if (reward != null)
        {
            await PostRewardsToExternalApp(reward);
        }

        return req.CreateResponse(HttpStatusCode.OK);
    }

    [Function("SyncCompletedItems")]
    public async Task<HttpResponseData> SyncCompletedItems([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var user = await _userRepository.GetByIdAsync(ModelConstants.USER_ID);
        if (user == null)
        {
            _logger.LogError("Couldn't find user with ID: " + ModelConstants.USER_ID);
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }

        var getLastCompletedItem = user?.LastCompletedItem?.CompletedDate ?? DateTime.MinValue;
        var result = await _itemRepository.GetBySpecificationAsync($"since={getLastCompletedItem}");

        await _rewardService.RegisterRewardsOnUserAsync(result, ModelConstants.USER_ID);

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }

    private async Task PostRewardsToExternalApp(Reward reward)
    {
        var item = new TodoItem()
        {
            Content = reward.Title,
            ProjectId = ExternalTodoConstants.REWARDS_PROJECT_ID,
            DueDate = DateTime.UtcNow
        };
        await _itemRepository.AddAsync(item);
    }
}
