using Core;
using MontyHall.Domain.Exceptions;
using System.Collections.Generic;

namespace MontyHall.Domain.MontyPlayerAggregate
{
    public sealed class Doors : ValueObject
    {
        private readonly List<Door> _doors;

        // make it of Type Immutable List C#
        public List<Door> DoorList { get; private set; }

        public Doors()
        {
            _doors = new List<Door> { Door.Car, Door.Goat, Door.Goat };
            _doors.Shuffle();
            DoorList = _doors;
        }


        public Door SelectDoor(int doorNumber)
        {
            if (doorNumber > 2 || doorNumber < 0)
            {
                throw new InvalidDoorException(doorNumber);
            }

            return DoorList[doorNumber];
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DoorList;
        }
    }
}