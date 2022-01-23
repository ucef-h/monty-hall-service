using MontyHall.Domain.MontyPlayerAggregate;
using NUnit.Framework;
using System;

namespace MontyHall.Domain.Tests
{
    public class MontyPlayerTest
    {
        [Test]
        public void TestPlayerData()
        {
            var numberOfGames = 10000;
            var player = new MontyPlayer(PlayerStrategy.KeepSameDoor);
            Assert.AreEqual(PlayerStrategy.KeepSameDoor, player.Strategy);

            player.Play(numberOfGames);
            Assert.AreEqual(numberOfGames, player.PlayCount);
        }
    }
}