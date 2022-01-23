using Core;

namespace MontyHall.Domain.MontyPlayerAggregate
{
    public class Door : Enumeration
    {
        public static readonly Door Car = new Door(1, nameof(Car).ToLowerInvariant());
        public static readonly Door Goat = new Door(2, nameof(Goat).ToLowerInvariant());

        protected Door(int id, string name) : base(id, name)
        {
        }
    }
}