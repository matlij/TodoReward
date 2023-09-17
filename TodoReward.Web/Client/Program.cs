using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Mapper;
using TodoReward.Infrastructure.Models.ExternalModels;
using TodoReward.Infrastructure.Models.StorageTable;
using TodoReward.Infrastructure.Options;
using TodoReward.Infrastructure.Repositories;

namespace TodoReward.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("Todoist", client =>
            {
                var token = "b2918522371f89a1a298596aaeb0f6b544f8673b";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.BaseAddress = new Uri("https://api.todoist.com/sync/v9/");
            });

            builder.Services.AddAutoMapper(typeof(GeneralProfile));
            builder.Services.AddTransient<IGenericRepository<TodoItem>, WebApiGenericRepository<TodoItem, ExternalTodoItemList>>();
            builder.Services.AddTransient<IGenericRepository<User>, TableStorageRepository<User, UserEntity>>();

            builder.Services.Configure<StorageTableOptions>(o =>
            {
                o.ConnectionString = builder.Configuration.GetConnectionString("StorageAccount") ?? throw new KeyNotFoundException("Failed to find connectionstring with key StorageTable");
                o.TableName = "Users";
            });

            await builder.Build().RunAsync();
        }
    }
}