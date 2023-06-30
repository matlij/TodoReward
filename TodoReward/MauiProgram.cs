using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoReward.Pages;
using TodoReward.Services;
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

        builder.Services.AddSingleton<ITodoItemService, TodoItemService>(); //Use AddTransient when items are not stored in memory 

        return builder.Build();
	}
}
