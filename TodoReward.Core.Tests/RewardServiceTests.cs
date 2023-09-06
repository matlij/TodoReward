using TodoReward.Core;

namespace TodoReward.Tests
{
    [TestClass]
    public class RewardServiceTests
    {
        private RewardService _rewardService;
        private Mock<IGenericRepository<Reward>> _rewardRepositoryMock;

        [TestInitialize]
        public void SetUp()
        {
            _rewardRepositoryMock = new Mock<IGenericRepository<Reward>>();
            _rewardService = new RewardService(_rewardRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetRewardAsync_UserHasEnoughPoints_ReturnsRandomReward()
        {
            // Arrange
            var user = new User { TotalPoints = 5 };
            var rewards = new List<Reward>
            {
                new Reward { Id = Guid.NewGuid(), Title = "Reward 1", Propability = 1 },
                new Reward { Id = Guid.NewGuid(), Title = "Reward 2", Propability = 1 }
            };
            _rewardRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(rewards);

            // Act
            var result = await _rewardService.GetRewardAsync(user);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(rewards.Any(r => r.Id == result?.Id));
        }

        [TestMethod]
        public async Task GetRewardAsync_UserDoesNotHaveEnoughPoints_ReturnsNull()
        {
            // Arrange
            var user = new User { TotalPoints = 1 };
            var rewards = new List<Reward>
            {
                new Reward { Id = Guid.NewGuid(), Title = "Reward 1", Propability = 1 },
                new Reward { Id = Guid.NewGuid(), Title = "Reward 2", Propability = 1 }
            };
            _rewardRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(rewards);

            // Act
            var result = await _rewardService.GetRewardAsync(user);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task HasReachedNextMilestone_UserHasReachedNextMilestone_ReturnsRewards()
        {
            // Arrange
            var user = new User { MilstonesReached = 1, TotalPointsRewarded = 10 };
            var rewards = new List<Reward>
            {
                new Reward { Id = Guid.NewGuid(), Title = "Reward 1", Propability = 1 },
                new Reward { Id = Guid.NewGuid(), Title = "Reward 2", Propability = 1 }
            };
            _rewardRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(rewards);

            // Act
            var milestoneRewards = await _rewardService.GetRewardsForMilestone(user);

            // Assert
            Assert.AreEqual(4, milestoneRewards?.Count()); // 1 Milestone reached * 2 rewards per milestone + 2 additional rewards
        }

        [TestMethod]
        public async Task HasReachedNextMilestone_UserHasNotReachedNextMilestone_ReturnsNoRewards()
        {
            // Arrange
            var user = new User { MilstonesReached = 1, TotalPointsRewarded = 8 };
            var rewards = new List<Reward>
            {
                new Reward { Id = Guid.NewGuid(), Title = "Reward 1", Propability = 1 },
                new Reward { Id = Guid.NewGuid(), Title = "Reward 2", Propability = 1 }
            };
            _rewardRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(rewards);

            // Act
            var milestoneRewards = await _rewardService.GetRewardsForMilestone(user);

            // Assert
            Assert.AreEqual(null, milestoneRewards?.Count());
        }

        [TestMethod]
        public async Task HasReachedNextMilestone_UserUpdateFails_ThrowsInvalidOperationException()
        {
            // Arrange
            var user = new User { MilstonesReached = 1, TotalPointsRewarded = 10 };
            var rewards = new List<Reward>
            {
                new Reward { Id = Guid.NewGuid(), Title = "Reward 1", Propability = 1 },
                new Reward { Id = Guid.NewGuid(), Title = "Reward 2", Propability = 1 }
            };
            _rewardRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(rewards);

            // Act + Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _rewardService.GetRewardsForMilestone(user));
        }
    }
}
