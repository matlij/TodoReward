using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using TodoReward.Core;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Mapper;
using TodoReward.Infrastructure.Models.ExternalModels;
using TodoReward.Infrastructure.Models.StorageTable;
using TodoReward.Infrastructure.Options;
using TodoReward.Infrastructure.Repositories;

var hostBuilder = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<StorageTableOptions<UserEntity>>(context.Configuration.GetSection($"{StorageTableOptions<UserEntity>.Name}:Users"));
        services.Configure<StorageTableOptions<UserRewardEntity>>(context.Configuration.GetSection($"{StorageTableOptions<UserRewardEntity>.Name}:UserRewards"));

        services.AddScoped<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItemList>>();
        services.AddScoped<IGenericRepository<User>, TableStorageRepository<User, UserEntity>>();
        services.AddScoped<IGenericRepository<UserReward>, TableStorageRepository<UserReward, UserRewardEntity>>();
        services.AddSingleton<IGenericRepository<Reward>, InMemoryRepository<Reward>>(s => new InMemoryRepository<Reward>(GetRewards()));

        services.AddScoped<IRewardService, RewardService>();

        services.AddAutoMapper(typeof(GeneralProfile));
        
        var bearerToken = context.Configuration.GetValue<string>("TokenExternalApi");
        services.AddHttpClient<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItemList>>(client =>
        {
            client.BaseAddress = new Uri("https://api.todoist.com/sync/v9/completed/get_all");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        });
        services.AddHttpClient<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItem>>(client =>
        {
            client.BaseAddress = new Uri("https://api.todoist.com/rest/v2/tasks");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        });
    });

IList<Reward> GetRewards()
{
    return new Reward[]
        {
            new Reward { Title = "Go on a Weekend trip", Propability = 10 },
            new Reward { Title = "One episode on TV", Propability = 1000 },
            new Reward { Title = "One movie on TV", Propability = 1000 },
            new Reward { Title = "30 min gaming", Propability = 100 },
            new Reward { Title = "One podcast episode", Propability = 1000 },
            new Reward { Title = "15 min book reading", Propability = 500 },
            new Reward { Title = "Beer", Propability = 1000 },
            new Reward { Title = "Glas of Wine", Propability = 200 },
            new Reward { Title = "Candy", Propability = 500 },
            new Reward { Title = "Soda", Propability = 500 },
            new Reward { Title = "Coffea", Propability = 1000 },
            new Reward { Title = "Yerba mate", Propability = 500 },
            new Reward { Title = "Tea", Description = "Enjoy a cup of tea", Propability = 1000 },
            new Reward { Title = "Outside lunch", Propability = 100 },
            new Reward { Title = "Dessert after dinner", Propability = 100 },
            new Reward { Title = "Home made Pizza", Propability = 200 },
            new Reward { Title = "Cinema", Propability = 100 },
            new Reward { Title = "After dinner snack", Propability = 500 },
        };
}

hostBuilder.Build().Run();
