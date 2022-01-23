using Core;

namespace MontyHall.Domain.MontyPlayerAggregate
{
    public class PlayerStrategy : Enumeration
    {
        public static PlayerStrategy KeepSameDoor = new PlayerStrategy(1, nameof(KeepSameDoor).ToLowerInvariant());
        public static PlayerStrategy SwitchDoor = new PlayerStrategy(2, nameof(SwitchDoor).ToLowerInvariant());

        protected PlayerStrategy(int id, string name) : base(id, name)
        {
        }

        public static PlayerStrategy Create(bool shouldSwitchDoors)
        {
            return shouldSwitchDoors ? SwitchDoor : KeepSameDoor;
        }
    }
}