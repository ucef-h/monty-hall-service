using Core;
using MontyHall.Domain.Events;
using System;

namespace MontyHall.Domain.MontyPlayerAggregate
{
    public class MontyPlayer : BaseEntity, IAggregateRoot
    {
        private readonly Random _random = new Random();
        public PlayerStrategy Strategy { get; private set; }
        public int PlayCount { get; private set; }
        public int WinCount { get; private set; }

        public MontyPlayer(PlayerStrategy playerStrategy)
        {
            AddPlayerCreated(playerStrategy);
        }

        private void AddPlayerCreated(PlayerStrategy playerStrategy)
        {
            Strategy = playerStrategy;
            AddPlayerCreatedEvent(playerStrategy);
        }

        public void Play(int numberOfGames)
        {
            int playCount = 0;
            int winCount = 0;

            for (int i = 0; i < numberOfGames; i++)
            {
                var didWin = new MontyHallGame(_random.Next(3), Strategy).PlayGame();
                if (didWin)
                {
                    winCount++;
                }
                    
                playCount++;
            }

            WinCount = winCount;
            PlayCount = playCount;

            AddPlayerFinishedGameEvent(winCount, playCount);
        }

        private void AddPlayerCreatedEvent(PlayerStrategy playerStrategy)
        {
            var playerCreatedEvent = new PlayerCreated(playerStrategy);
            AddDomainEvent(playerCreatedEvent);
        }

        private void AddPlayerFinishedGameEvent(int winCount, int playCount)
        {
            var playerFinishedGame = new PlayerFinishedGame(winCount, playCount);
            AddDomainEvent(playerFinishedGame);
        }

        public GameResult GameResult()
        {
            return new GameResult(Strategy, PlayCount, WinCount);
        }
    }
}