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
            new Reward { Title = "15 min streaming", Propability = 1000 },
            new Reward { Title = "15 min gaming", Propability = 500 },
            new Reward { Title = "30 min podcast", Propability = 1000 },
            new Reward { Title = "30 min book reading", Propability = 500 },
            new Reward { Title = "One beer", Propability = 1000 },
            new Reward { Title = "One candy", Propability = 500 },
            new Reward { Title = "One soda", Propability = 500 },
            new Reward { Title = "One cup of coffea", Propability = 1000 },
            new Reward { Title = "One cup of tea", Propability = 1000 },
            new Reward { Title = "Outside lunch", Propability = 100 },
            new Reward { Title = "Dessert after dinner", Propability = 100 },    
            new Reward { Title = "Home made Pizza", Propability = 200 },
            new Reward { Title = "Weekend", Propability = 10 }
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
