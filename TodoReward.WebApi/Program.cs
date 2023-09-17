using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Mapper;
using TodoReward.Infrastructure.Models.ExternalModels;
using TodoReward.Infrastructure.Repositories;

var hostBuilder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults();

hostBuilder.ConfigureServices(services =>
{
    services.AddScoped<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItemList>>();
    services.AddAutoMapper(typeof(GeneralProfile));
    services.AddHttpClient<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItemList>>(client =>
    {
        client.BaseAddress = new Uri("https://api.todoist.com/sync/v9/completed/get_all");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "b2918522371f89a1a298596aaeb0f6b544f8673b");
    });

});


hostBuilder.Build().Run();
