namespace TodoReward.Core.Tests.Models;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void TotalPointsNotRewarded_Should_Return_Correct_Value()
    {
        // Arrange
        var user = new User
        {
            TotalPoints = 100,
            TotalPointsRewarded = 30
        };

        // Act
        var totalPointsNotRewarded = user.TotalPointsNotRewarded;

        // Assert
        Assert.AreEqual(70, totalPointsNotRewarded);
    }

    [TestMethod]
    public void NoOfRewardsInCurrentMilestone_Should_Return_Correct_Value()
    {
        // Arrange
        var user = new User
        {
            MilstonesReached = 2
        };

        // Act
        var noOfRewardsInCurrentMilestone = user.NoOfRewardsInCurrentMilstone;

        // Assert
        Assert.AreEqual(6, noOfRewardsInCurrentMilestone);
    }

    [TestMethod]
    public void PointsToNextMilestone_Should_Return_Correct_Value()
    {
        // Arrange
        var user = new User
        {
            MilstonesReached = 3
        };

        // Act
        var pointsToNextMilestone = user.NextMileStone;

        // Assert
        Assert.AreEqual(50, pointsToNextMilestone);
    }

    [TestMethod]
    public void PercentageCompletedOfNextMilestone_Should_Return_Correct_Value()
    {
        // Arrange
        var user = new User
        {
            TotalPoints = 40,
            MilstonesReached = 2
        };

        // Act
        var percentageCompleted = user.PercentageCompletedOfNextMilestone;

        // Assert
        Assert.AreEqual(0.25, percentageCompleted);
    }

    [TestMethod]
    public void HasReachedMilestone_Should_Return_Correct_Value()
    {
        // Arrange
        var user = new User
        {
            TotalPoints = 60,
            MilstonesReached = 1
        };

        // Act
        var hasReachedMilestone = user.HasReachedMilestone;

        // Assert
        Assert.IsTrue(hasReachedMilestone);
    }
}
