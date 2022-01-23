using MontyHall.Domain.MontyPlayerAggregate;
using NUnit.Framework;

namespace MontyHall.Domain.Tests
{
    public class PlayerStrategyTest
    {

        [Test]
        public void TestDoorValues()
        {
            Assert.AreEqual(PlayerStrategy.SwitchDoor, PlayerStrategy.SwitchDoor);
            Assert.AreEqual(PlayerStrategy.KeepSameDoor, PlayerStrategy.KeepSameDoor);
            
            Assert.AreEqual(PlayerStrategy.SwitchDoor.Name, "switchdoor");
            Assert.AreEqual(PlayerStrategy.KeepSameDoor.Name, "keepsamedoor");
            
            Assert.AreEqual(PlayerStrategy.Create(false), PlayerStrategy.KeepSameDoor);
            Assert.AreEqual(PlayerStrategy.Create(true), PlayerStrategy.SwitchDoor);
        }
    }
}