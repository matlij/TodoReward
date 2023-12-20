using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Core;
using TodoReward.Infrastructure.Mapper;
using TodoReward.Infrastructure.Models.ExternalModels;
using TodoReward.Infrastructure.Models.StorageTable;
using TodoReward.Infrastructure.Options;
using TodoReward.Infrastructure.Repositories;
using System.Collections.Frozen;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.Configure<StorageTableOptions<UserEntity>>(context.Configuration.GetSection($"{StorageTableOptions<UserEntity>.Name}:Users"));
        services.Configure<StorageTableOptions<UserRewardEntity>>(context.Configuration.GetSection($"{StorageTableOptions<UserRewardEntity>.Name}:UserRewards"));
        services.Configure<StorageTableOptions<TodoItemEntity>>(context.Configuration.GetSection($"{StorageTableOptions<UserRewardEntity>.Name}:TodoItems"));

        services.AddScoped<IGenericRepository<User>, TableStorageRepository<User, UserEntity>>();
        services.AddScoped<IGenericRepository<UserReward>, TableStorageRepository<UserReward, UserRewardEntity>>();
        services.AddSingleton<IGenericReadonlyRepository<Reward>, InMemoryReadonlyRepository<Reward>>(
            s => new InMemoryReadonlyRepository<Reward>(GetRewards()));
        services.AddSingleton<IGenericReadonlyRepository<Challange>, InMemoryReadonlyRepository<Challange>>(
            s => new InMemoryReadonlyRepository<Challange>(GetChallanges()));

        services.AddScoped<IRewardService, RewardService>();

        services.AddAutoMapper(typeof(GeneralProfile));

        var bearerToken = context.Configuration.GetValue<string>("TokenExternalApi");

        //services.AddHttpClient<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, TodoistTodoItemList>>(client =>
        //{
        //    client.BaseAddress = new Uri("https://api.todoist.com/sync/v9/completed/get_all");
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        //});
        services.AddHttpClient<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, TodoistCreateTask>>(client =>
        {
            client.BaseAddress = new Uri("https://api.todoist.com/rest/v2/tasks");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        });

        //services.AddScoped<IGenericRepository<TodoItem>, TableStorageRepository<TodoItem, TodoItemEntity>>();

    })
    .Build();

host.Run();

FrozenSet<Reward> GetRewards()
{
    return new Reward[]
    {
        new() { Title = "Go on a Weekend trip", Propability = 10 },
        new() { Title = "One episode on TV", Propability = 1000 },
        new() { Title = "One movie on TV", Propability = 1000 },
        new() { Title = "30 min gaming", Propability = 100 },
        new() { Title = "One podcast episode", Propability = 1000 },
        new() { Title = "15 min book reading", Propability = 500 },
        new() { Title = "Beer", Propability = 1000 },
        new() { Title = "Glas of Wine", Propability = 200 },
        new() { Title = "Candy", Propability = 500 },
        new() { Title = "Soda", Propability = 500 },
        new() { Title = "Coffea", Propability = 1000 },
        new() { Title = "Yerba mate", Propability = 500 },
        new() { Title = "Tea", Description = "Enjoy a cup of tea", Propability = 1000 },
        new() { Title = "Outside lunch", Propability = 100 },
        new() { Title = "Dessert after dinner", Propability = 100 },
        new() { Title = "Home made Pizza", Propability = 200 },
        new() { Title = "Cinema", Propability = 100 },
        new() { Title = "After dinner snack", Propability = 500 },
    }.ToFrozenSet();
}

FrozenSet<Challange> GetChallanges()
{
    return new Challange[]
    {
        new() { Title = "No screens afer work" },
        new() { Title = "No screens afer 21.00" },
        new() { Title = "100 push ups" },
        new() { Title = "No food after dinner" },
        new() { Title = "10 min yoga" },
        new() { Title = "10 000 steps" },
        new() { Title = "Read a book 30 min" },
        new() { Title = "Pluralsight 30 min" },
        new() { Title = "1 hour coding on a home project" },
        new() { Title = "Write down three things you're grateful for" },
        new() { Title = "No spending on fooed" },
        new() { Title = "Complementing others" },
        new() { Title = "30 min house fixing" }
    }.ToFrozenSet();
}