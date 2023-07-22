namespace TodoReward.Core.Tests;

[TestClass]
public class RewardServiceTests
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Mock<IGenericRepository<Reward>> _repositoryMock;
    private RewardService _rewardService;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    // Test initializer
    [TestInitialize]
    public void Setup()
    {
        // Create a new repository mock and reward service instance before each test
        _repositoryMock = new Mock<IGenericRepository<Reward>>();
        _rewardService = new RewardService(_repositoryMock.Object);
    }

    // Test case 2: Test when the repository returns an empty rewards array
    [TestMethod]
    public async Task GenerateRandomAsync_WhenRepositoryReturnsEmptyArray_ReturnsUnknownReward()
    {
        // Arrange
        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new Reward[0]);

        // Act
        var result = await _rewardService.GenerateRandomAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Unknown", result.Title);
    }

    // Test case 3: Test when the repository returns some rewards
    [TestMethod]
    public async Task GenerateRandomAsync_WhenRepositoryReturnsRewards_ReturnsRandomReward()
    {
        // Arrange
        var rewards = new[]
        {
            new Reward { Id = Guid.NewGuid(), Title = "Reward1", Propability = 1 },
            new Reward { Id = Guid.NewGuid(), Title = "Reward2", Propability = 100 },
            new Reward { Id = Guid.NewGuid(), Title = "Reward3", Propability = 1000 }
        };

        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(rewards);

        // Act
        var result = await _rewardService.GenerateRandomAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Id != Guid.Empty);
        Assert.IsFalse(string.IsNullOrEmpty(result.Title));
    }

    // Add more test cases to cover other scenarios if needed.
}
