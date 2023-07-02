using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoReward.BusinessLayer;
using TodoReward.BusinessLayer.Interfaces;
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

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<AddItemViewModel>();

        builder.Services.AddSingleton<ITodoItemRepository, TodoItemRepository>(); //Use AddTransient when items are not stored in memory 
        builder.Services.AddSingleton<IUserRepository, UserRepository>(); //Use AddTransient when items are not stored in memory 
        builder.Services.AddSingleton<IRewardRepository, RewardRepository>(); //Use AddTransient when items are not stored in memory 

        builder.Services.AddTransient<ITodoItemService, TodoItemService>();

        return builder.Build();
	}
}
