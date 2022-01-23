using MontyHall.Domain.MontyPlayerAggregate;
using NUnit.Framework;

namespace MontyHall.Domain.Tests.Integration
{
    public class MontyPlayerGameResultIntegrationTest
    {
        [Test]
        [Repeat(1000)]
        public void TestPlayerKeepDoorChance()
        {
            var numberOfGames = 10000;
            var player = new MontyPlayer(PlayerStrategy.KeepSameDoor);
            player.Play(numberOfGames);
            var gameResult = player.GameResult();
            Assert.That(gameResult.ProbabilityOfWinning * 100, Is.EqualTo(33).Within(10).Percent);
        }

        [Test]
        [Repeat(1000)]
        public void TestPlayerSwitchDoorChance()
        {
            var numberOfGames = 10000;
            var player = new MontyPlayer(PlayerStrategy.SwitchDoor);
            player.Play(numberOfGames);
            var gameResult = player.GameResult();
            Assert.That(gameResult.ProbabilityOfWinning * 100, Is.EqualTo(66).Within(10).Percent);
        }
    }
}