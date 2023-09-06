using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
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
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MaterialIconsOutlined-Regular");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PutItemPage>();
        builder.Services.AddTransient<RewardPage>();
        builder.Services.AddTransient<UserPage>();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<PutItemViewModel>();
        builder.Services.AddTransient<RewardViewModel>();
        builder.Services.AddTransient<UserViewModel>();

        builder.Services.Configure<DatabaseOptions>(options => options.DatabasePath = FileSystem.AppDataDirectory);

        builder.Services.Configure<DbContextOptionsBuilder<MyDbContext>>(
            o => o.UseSqlite($"Filename={GetDatabasePath()}", x => x.MigrationsAssembly(Assembly.GetAssembly(typeof(MyDbContext)).FullName)));

        builder.Services.AddTransient<IGenericRepository<TodoItem>, LocalDbRepository<TodoItem>>();
        builder.Services.AddTransient<IGenericRepository<User>, LocalDbRepository<User>>();
        builder.Services.AddTransient<IGenericRepository<TodoReward.Core.Models.UserReward>, LocalDbRepository<TodoReward.Core.Models.UserReward>>();
        builder.Services.AddTransient<IGenericRepository<Reward>, LocalDbRepository<Reward>>();

        builder.Services.AddTransient<ITodoItemService, TodoItemService>();
        builder.Services.AddTransient<IRewardService, RewardService>();

        return builder.Build();
	}

    public static string GetDatabasePath()
    {
        var databasePath = "";
        var databaseName = "TodoReward.sqlite3";

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
        }
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            SQLitePCL.Batteries_V2.Init();
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
        }
        if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            databasePath = Path.Combine("C:\\MyApp", databaseName); //TODO
        }

        return databasePath;

    }
}
