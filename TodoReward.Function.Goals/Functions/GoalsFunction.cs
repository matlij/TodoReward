using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TodoReward.Core.Extensions;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Core.Models.Constants;

namespace TodoReward.Functions.Functions;

public class GoalsFunction
{
    private readonly ILogger _logger;
    private readonly IGenericRepository<Core.Models.TodoItem> _itemRepository;
    private readonly IGenericReadonlyRepository<Challange> _challangeRepository;

    public GoalsFunction(ILoggerFactory loggerFactory,
        IGenericRepository<Core.Models.TodoItem> itemRepository,
        IGenericReadonlyRepository<Challange> challangeRepository)
    {
        _logger = loggerFactory.CreateLogger<TodoRewardFunction>();
        _itemRepository = itemRepository;
        _challangeRepository = challangeRepository;
    }

    [Function("CreateWeeklyChallangeFunction")]
    public async Task Run([TimerTrigger("0 0 5 * * Mon")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }

#if !DEBUG
        if (DateTime.UtcNow.Date.DayOfWeek != DayOfWeek.Monday)
        {
            throw new InvalidOperationException("Weekly challange function triggered on wrong day: " + DateTime.UtcNow.ToShortDateString());
        }
#endif
        var challanges = await _challangeRepository.GetAllAsync();
        var challange = challanges.GetRandom();

        var todoItem = new Core.Models.TodoItem()
        {
            Content = challange.Title,
            DueString = $"varje dag slut {DateTime.UtcNow.AddDays(7).ToShortDateString()}",
            ProjectId = ExternalTodoConstants.WEEKLYCHALLANGES_PROJECT_ID
        };

        await _itemRepository.AddAsync(todoItem);
    }
}
