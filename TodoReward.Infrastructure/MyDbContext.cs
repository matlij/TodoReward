using Microsoft.EntityFrameworkCore;
using TodoReward.Core.Models;
using TodoReward.Core.Models.Constants;

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
            new Reward { Title = "Go on a Weekend trip", Propability = 10 },
            new Reward { Title = "One episode on TV", Propability = 1000 },
            new Reward { Title = "One movie on TV", Propability = 1000 },
            new Reward { Title = "30 min gaming", Propability = 500 },
            new Reward { Title = "One podcast episode", Propability = 1000 },
            new Reward { Title = "30 min book reading", Propability = 500 },
            new Reward { Title = "Beer", Propability = 1000 },
            new Reward { Title = "Glas of Wine", Propability = 200 },
            new Reward { Title = "Candy", Propability = 500 },
            new Reward { Title = "Soda", Propability = 500 },
            new Reward { Title = "Coffea", Propability = 1000 },
            new Reward { Title = "Tea", Description = "Enjoy a cup of tea", Propability = 1000 },
            new Reward { Title = "Outside lunch", Propability = 100 },
            new Reward { Title = "Dessert after dinner", Propability = 100 },    
            new Reward { Title = "Home made Pizza", Propability = 200 },
            new Reward { Title = "Cinema", Propability = 100 },

        };
        modelBuilder.Entity<Reward>().HasData(rewards);

        var user = new User()
        {
            Id = ModelConstants.USER_ID
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
