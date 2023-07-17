
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using TodoReward.Core;
using TodoReward.Core.Models;
using TodoReward.Infrastructure;
using TodoReward.Infrastructure.Repositories;

var opt = Options.Create(new DbContextOptionsBuilder<MyDbContext>());
opt.Value.UseSqlite("Data Source=C:\\MyApp\\todo.sqlite3", x => x.MigrationsAssembly(Assembly.GetAssembly(typeof(MyDbContext))?.FullName));

//await GetAndUpdateReward(opt);

var userRepository = new LocalDbRepository<User>(opt);
var rewardRepository = new LocalDbRepository<Reward>(opt);
var userRewardRepository = new LocalDbRepository<UserReward>(opt);

var rewardService = new RewardService(rewardRepository);


var user = (await userRepository.GetAllAsync()).First();
user.TotalPoints += 1;
user.TotalPointsRewarded += 4;
//user.Rewards.Add(new UserReward { Reward = new Reward() });
var result = await userRepository.UpdateAsync(user.Id, user);

var reward = await rewardService.GenerateRandomAsync();
await userRewardRepository.AddAsync(new UserReward { RewardId = reward.Id, UserId = user.Id });

Console.WriteLine("Update user result: " + result);

static async Task<IEnumerable<Reward>> GetAndPrintRewards(LocalDbRepository<Reward> repo)
{
    await Console.Out.WriteLineAsync("Rewards:");

    var result = await repo.GetAllAsync();
    foreach (var item in result)
    {
        await Console.Out.WriteLineAsync(item.Title);
    }

    await Console.Out.WriteLineAsync("");

    return result;
}

static async Task GetAndUpdateReward(IOptions<DbContextOptionsBuilder<MyDbContext>> opt)
{
    var repo = new LocalDbRepository<Reward>(opt);

    var rewards = await GetAndPrintRewards(repo);

    var reward = rewards.First();
    reward.Title = reward.Title + "1";

    await repo.UpdateAsync(reward.Id, reward);

    var _ = await GetAndPrintRewards(repo);
}