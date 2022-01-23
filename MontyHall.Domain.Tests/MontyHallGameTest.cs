using MontyHall.Domain.Exceptions;
using MontyHall.Domain.MontyPlayerAggregate;
using NUnit.Framework;

namespace MontyHall.Domain.Tests
{
    public class MontyHallGameTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [Repeat(10)]
        public void TestGameKeepDoor(int chosenDoor)
        {
            var game = new MontyHallGame(chosenDoor, PlayerStrategy.KeepSameDoor);
            var didWin = game.PlayGame();
            Assert.AreEqual(didWin, game.Doors.SelectDoor(chosenDoor).Equals(Door.Car));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [Repeat(10)]
        public void TestGameSwitchDoor(int chosenDoor)
        {
            var game = new MontyHallGame(chosenDoor, PlayerStrategy.SwitchDoor);
            var didWin = game.PlayGame();
            Assert.AreEqual(didWin, game.Doors.SelectDoor(chosenDoor).Equals(Door.Goat));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(3)]
        public void TestGameSwitchDoorThrowsInvalidDoorException(int chosenDoor)
        {
            var game = new MontyHallGame(chosenDoor, PlayerStrategy.SwitchDoor);
            Assert.Throws(typeof(InvalidDoorException), () => game.PlayGame());
        }
    }
}