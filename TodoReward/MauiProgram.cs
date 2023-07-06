using AutoBogus;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoReward.BusinessLayer;
using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;
using TodoReward.BusinessLayer.Repositories;
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

        builder.Services.AddScoped<IGenericRepository<TodoItem>, GenericRepository<TodoItem>>();
        builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        builder.Services.AddScoped<IGenericRepository<Reward>, GenericRepository<Reward>>();

        builder.Services.AddTransient<ITodoItemService, TodoItemService>();
        builder.Services.AddTransient<IRewardService, RewardService>();

        return builder.Build();
	}
}
