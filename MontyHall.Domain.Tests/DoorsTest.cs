using MontyHall.Domain.Exceptions;
using MontyHall.Domain.MontyPlayerAggregate;
using NUnit.Framework;
using System.Linq;

namespace MontyHall.Domain.Tests
{
    public class DoorsTest
    {
        [Test]
        public void TestDoorsContent()
        {
            var doors = new Doors();
            
            Assert.AreEqual(3, doors.DoorList.Count);
            Assert.Contains(Door.Car, doors.DoorList);
            Assert.Contains(Door.Goat, doors.DoorList);
            
            Assert.AreEqual(2, doors.DoorList.Count(e => e.Equals(Door.Goat)));
            Assert.AreEqual(1, doors.DoorList.Count(e => e.Equals(Door.Car)));
        }
        
        [Test]
        public void TestDoorsBehaviour()
        {
            var doors = new Doors();
            Assert.IsTrue(doors.SelectDoor(0).Equals(doors.DoorList[0]));
            Assert.IsTrue(doors.SelectDoor(1).Equals(doors.DoorList[1]));
            Assert.IsTrue(doors.SelectDoor(2).Equals(doors.DoorList[2]));
        }
        
        [Test]
        public void TestDoorsBehaviourException()
        {
            var doors = new Doors();
            Assert.Throws(typeof(InvalidDoorException), () => doors.SelectDoor(3));
            Assert.Throws(typeof(InvalidDoorException), () => doors.SelectDoor(4));
            Assert.Throws(typeof(InvalidDoorException), () => doors.SelectDoor(-1));
            Assert.Throws(typeof(InvalidDoorException), () => doors.SelectDoor(-2));
        }

    }
}