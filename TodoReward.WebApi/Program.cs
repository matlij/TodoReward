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
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItemList>>();
        services.AddScoped<IGenericRepository<User>, TableStorageRepository<User, UserEntity>>();
        services.AddScoped<IGenericRepository<UserReward>, TableStorageRepository<UserReward, UserRewardEntity>>();
        services.AddSingleton<IGenericRepository<Reward>, InMemoryRepository<Reward>>(s => new InMemoryRepository<Reward>(GetRewards()));

        services.AddScoped<IRewardService, RewardService>();
        services
            .AddOptions<StorageTableOptions<UserEntity>>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                options.TableName = "Users";
                options.ConnectionString = "DefaultEndpointsProtocol=https;AccountName=todorewardsa;AccountKey=lbeUm0F3zU624bDNim1ZW3Sb9yiBxOiTKP7bDXWencjoZ4w6aLDxTgd40lgcLYi5U40hIlkLX4tT+AStxvxGOw==;EndpointSuffix=core.windows.net";
            });
        services
            .AddOptions<StorageTableOptions<UserRewardEntity>>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                options.TableName = "UserRewards";
                options.ConnectionString = "DefaultEndpointsProtocol=https;AccountName=todorewardsa;AccountKey=lbeUm0F3zU624bDNim1ZW3Sb9yiBxOiTKP7bDXWencjoZ4w6aLDxTgd40lgcLYi5U40hIlkLX4tT+AStxvxGOw==;EndpointSuffix=core.windows.net";
            });

        services.AddAutoMapper(typeof(GeneralProfile));
        services.AddHttpClient<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItemList>>(client =>
        {
            client.BaseAddress = new Uri("https://api.todoist.com/sync/v9/completed/get_all");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "b2918522371f89a1a298596aaeb0f6b544f8673b");
        });

    });

IList<Reward> GetRewards()
{
    return new List<Reward>()
    {
        new Reward()
        {
            Id = "35a87756-66ba-42a3-bfa6-57e79e21dd93",
            Title = "Beer",
            Propability = 10
        }
    };
}

hostBuilder.Build().Run();
