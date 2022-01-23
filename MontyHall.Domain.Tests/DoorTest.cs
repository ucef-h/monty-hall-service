using MontyHall.Domain.MontyPlayerAggregate;
using NUnit.Framework;

namespace MontyHall.Domain.Tests
{
    public class DoorTest
    {

        [Test]
        public void TestDoorValues()
        {
            Assert.AreEqual(Door.Car, Door.Car);
            Assert.AreEqual(Door.Goat, Door.Goat);
            Assert.AreNotEqual(Door.Car, Door.Goat);
            
            Assert.AreEqual(Door.Car.Name, "car");
            Assert.AreEqual(Door.Goat.Name, "goat");
        }
    }
}