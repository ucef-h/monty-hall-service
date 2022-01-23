using Core;
using MontyHall.Domain.MontyPlayerAggregate;

namespace MontyHall.Domain.Events
{
    public class PlayerCreated : DomainEvent
    {
        public PlayerStrategy Strategy { get; }

        public PlayerCreated(PlayerStrategy strategy)
        {
            Strategy = strategy;
        }
    }
}