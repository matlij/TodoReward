
namespace TodoReward.Core.Tests;

[TestClass]
public class TodoItemServiceTests
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Mock<IRewardService> _rewardServiceMock;
    private Mock<IGenericRepository<TodoItem>> _todoRepositoryMock;
    private Mock<IGenericRepository<User>> _userRepositoryMock;
    private Mock<IGenericRepository<UserReward>> _userRewardRepositoryMock;
    private TodoItemService _todoItemService;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        _rewardServiceMock = new Mock<IRewardService>();
        _todoRepositoryMock = new Mock<IGenericRepository<TodoItem>>();
        _userRepositoryMock = new Mock<IGenericRepository<User>>();
        _userRewardRepositoryMock = new Mock<IGenericRepository<UserReward>>();

        _todoItemService = new TodoItemService(
            _rewardServiceMock.Object,
            _todoRepositoryMock.Object,
            _userRepositoryMock.Object,
            _userRewardRepositoryMock.Object
        );
    }

    [TestMethod]
    public async Task CompleteItemAsync_ItemUpdateFails_ReturnsFalseAndNullReward()
    {
        // Arrange
        var todoItem = new TodoItem { Id = Guid.NewGuid(), Points = 10 };
        _todoRepositoryMock.Setup(repo => repo.UpdateAsync(todoItem.Id, todoItem)).ReturnsAsync(false);

        // Act
        var (success, reward) = await _todoItemService.CompleteItemAsync(todoItem);

        // Assert
        Assert.IsFalse(success);
        Assert.IsNull(reward);
    }

    [TestMethod]
    public async Task CompleteItemAsync_UserNotFound_ThrowsInvalidOperationException()
    {
        // Arrange
        var todoItem = new TodoItem { Id = Guid.NewGuid(), Points = 10 };
        _todoRepositoryMock.Setup(repo => repo.UpdateAsync(todoItem.Id, todoItem)).ReturnsAsync(true);
        _userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((User)null);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _todoItemService.CompleteItemAsync(todoItem));
    }

    [TestMethod]
    public async Task CompleteItemAsync_UserAndItemUpdateSucceeds_ReturnsTrueAndReward()
    {
        // Arrange
        var todoItem = new TodoItem { Id = Guid.NewGuid(), Points = 10 };
        var user = new User { Id = ModelConstants.UserId, TotalPoints = 20 };
        _todoRepositoryMock.Setup(repo => repo.UpdateAsync(todoItem.Id, todoItem)).ReturnsAsync(true);
        _userRepositoryMock.Setup(repo => repo.GetByIdAsync(ModelConstants.UserId)).ReturnsAsync(user);
        _rewardServiceMock.Setup(service => service.GenerateRandomAsync()).ReturnsAsync(new Reward { Id = Guid.NewGuid(), Title = "Test Reward" });
        _userRepositoryMock.Setup(repo => repo.UpdateAsync(user.Id, user)).ReturnsAsync(true);

        // Act
        var (success, reward) = await _todoItemService.CompleteItemAsync(todoItem);

        // Assert
        Assert.IsTrue(success);
        Assert.IsNotNull(reward);
        Assert.AreEqual("Test Reward", reward.Title);
    }

    // Add more test cases to cover other scenarios if needed.
}
