using MontyHall.Domain.Exceptions;
using MontyHall.Domain.MontyPlayerAggregate;
using NUnit.Framework;

namespace MontyHall.Domain.Tests
{
    public class GameResultTest
    {
        [Test]
        [TestCase(false, 10, 100)]
        [TestCase(true, 100, 200)]
        public void TestGameResultValues(bool shouldSwitchDoor, int winCount, int playCount)
        {
            var gameResult = new GameResult(PlayerStrategy.Create(shouldSwitchDoor), playCount, winCount);

            Assert.AreEqual(PlayerStrategy.Create(shouldSwitchDoor), gameResult.PlayerStrategy);
            Assert.AreEqual(winCount, gameResult.WinCount);
            Assert.AreEqual(playCount, gameResult.PlayCount);
            Assert.AreEqual(winCount * 1.0 / playCount, gameResult.ProbabilityOfWinning);
        }

        [Test]
        public void TestGameResultThrowsException()
        {
            Assert.Throws(typeof(GameResultArgumentException),
                () => new GameResult(PlayerStrategy.KeepSameDoor, -5, 5));
            Assert.Throws(typeof(GameResultArgumentException),
                () => new GameResult(PlayerStrategy.KeepSameDoor, 5, -5));
            Assert.Throws(typeof(GameResultArgumentException),
                () => new GameResult(PlayerStrategy.KeepSameDoor, 100, 1000));
        }
    }
}