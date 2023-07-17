using Microsoft.EntityFrameworkCore;
using TodoReward.Core.Models;

namespace TodoReward.Infrastructure;

public class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .UseSqlite();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var rewards = new Reward[]
        {
            new Reward { Title = "HBO 30 min" },
            new Reward { Title = "Beer" },
        };
        modelBuilder.Entity<Reward>().HasData(rewards);

        var user = new User()
        {
            Id = ModelConstants.UserId
        };
        modelBuilder.Entity<User>().HasData(user);

        modelBuilder.Entity<UserReward>().HasData(new[]
        {
            new UserReward
            {
                RewardId = rewards.First().Id,
                UserId = user.Id,
            }
        });

        modelBuilder.Entity<User>()
            .Navigation(e => e.Rewards)
            .AutoInclude();
        modelBuilder.Entity<UserReward>()
            .Navigation(e => e.Reward)
            .AutoInclude();
    }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Reward> Rewards { get; set; }
    public DbSet<UserReward> UserRewards { get; set; }

}
