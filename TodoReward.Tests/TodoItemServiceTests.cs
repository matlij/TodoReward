using Moq;
using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Tests
{
    public class TodoItemServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IRewardRepository> _rewardRepositoryMock;
        private readonly Mock<ITodoItemRepository> _todoRepositoryMock;
        private readonly TodoItemService _sut;

        public TodoItemServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _todoRepositoryMock = new Mock<ITodoItemRepository>();
            _rewardRepositoryMock = new Mock<IRewardRepository>();
            _rewardRepositoryMock
                .Setup(repo => repo.GetRandomAsync())
                .ReturnsAsync(new Reward());

            _sut = new TodoItemService(_todoRepositoryMock.Object, _rewardRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task CompleteItemAsync_CompletesTodoItem_UpdatesItemAndReturnsReward()
        {
            // Arrange
            var item = new TodoItem
            {
                Points = 2
            };

            var user = new User
            {
                TotalPoints = 6,
                TotalPointsRewarded = 4
            };
            _userRepositoryMock.Setup(repo => repo.GetAsync())
                .ReturnsAsync(user);

            // Act
            var reward = await _sut.CompleteItemAsync(item);

            // Assert
            _userRepositoryMock.Verify(repo => repo.GetAsync(), Times.Once);
            _todoRepositoryMock.Verify(repo => repo.UpdateAsync(item.Id, item), Times.Once);
            _rewardRepositoryMock.Verify(repo => repo.GetRandomAsync(), Times.Once);
            Assert.NotNull(reward);
        }

        [Fact]
        public async Task CompleteItemAsync_CompletesTodoItem_NoRewardAvailable_ReturnsNull()
        {
            // Arrange
            var item = new TodoItem
            {
                Points = 1
            };

            var user = new User
            {
                TotalPoints = 2,
                TotalPointsRewarded = 0
            };
            _userRepositoryMock
                .Setup(repo => repo.GetAsync())
                .ReturnsAsync(user);

            // Act
            var reward = await _sut.CompleteItemAsync(item);

            // Assert
            _userRepositoryMock.Verify(repo => repo.GetAsync(), Times.Once);
            _todoRepositoryMock.Verify(repo => repo.UpdateAsync(item.Id, item), Times.Once);
            _rewardRepositoryMock.Verify(repo => repo.GetRandomAsync(), Times.Never);
            Assert.Null(reward);
        }
    }
}
