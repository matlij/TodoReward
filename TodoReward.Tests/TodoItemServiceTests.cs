using Moq;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Core.Tests
{
    public class TodoItemServiceTests
    {
        private readonly Mock<IGenericRepository<User>> _userRepositoryMock;
        private readonly Mock<IRewardService> _rewardRepositoryMock;
        private readonly Mock<IGenericRepository<TodoItem>> _todoRepositoryMock;
        private readonly TodoItemService _sut;

        public TodoItemServiceTests()
        {
            _userRepositoryMock = new Mock<IGenericRepository<User>>();
            _todoRepositoryMock = new Mock<IGenericRepository<TodoItem>>();
            _rewardRepositoryMock = new Mock<IRewardService>();
            _rewardRepositoryMock
                .Setup(repo => repo.GenerateRandomAsync())
                .ReturnsAsync(new Reward());

            _sut = new TodoItemService(_rewardRepositoryMock.Object, _todoRepositoryMock.Object, _userRepositoryMock.Object);
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
            _userRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new[] { user } );

            // Act
            var reward = await _sut.CompleteItemAsync(item);

            // Assert
            _userRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _todoRepositoryMock.Verify(repo => repo.UpdateAsync(item.Id, item), Times.Once);
            _rewardRepositoryMock.Verify(repo => repo.GenerateRandomAsync(), Times.Once);
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
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new[] { user });

            // Act
            var reward = await _sut.CompleteItemAsync(item);

            // Assert
            _userRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _todoRepositoryMock.Verify(repo => repo.UpdateAsync(item.Id, item), Times.Once);
            _rewardRepositoryMock.Verify(repo => repo.GenerateRandomAsync(), Times.Never);
            Assert.Null(reward);
        }
    }
}
