using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoReward.Core;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;
using TodoReward.Infrastructure;
using TodoReward.Infrastructure.Repositories;
using TodoReward.Pages;
using TodoReward.ViewModels;

namespace TodoReward;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddItemPage>();
        builder.Services.AddTransient<RewardPage>();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<AddItemViewModel>();
        builder.Services.AddTransient<RewardViewModel>();

        builder.Services.Configure<DatabaseOptions>(options => options.DatabasePath = FileSystem.AppDataDirectory);

        builder.Services.AddTransient<IGenericRepository<TodoItem>, LocalDbRepository<TodoItem>>();

        builder.Services.AddTransient<DbContext, TodoContext>();

        builder.Services.AddTransient<IGenericRepository<TodoItem>, LocalDbRepository<TodoItem>>();
        builder.Services.AddTransient<IGenericRepository<User>, LocalDbRepository<User>>();
        builder.Services.AddTransient<IGenericRepository<TodoReward.Core.Models.UserReward>, LocalDbRepository<TodoReward.Core.Models.UserReward>>();
        builder.Services.AddTransient<IGenericRepository<Reward>, LocalDbRepository<Reward>>();


        builder.Services.AddTransient<ITodoItemService, TodoItemService>();
        builder.Services.AddTransient<IRewardService, RewardService>();

        return builder.Build();
	}
}
