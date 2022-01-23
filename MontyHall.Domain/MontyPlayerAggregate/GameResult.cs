using Core;
using MontyHall.Domain.Exceptions;
using System.Collections.Generic;

namespace MontyHall.Domain.MontyPlayerAggregate
{
    public class GameResult : ValueObject
    {
        public GameResult(
            PlayerStrategy strategy,
            int playCount,
            int winCount)
        {
            if (winCount < 0)
            {
                throw new GameResultArgumentException("winCount cannot lower than 0");
            }

            if (playCount < 0)
            {
                throw new GameResultArgumentException("playCount cannot lower than 0");
            }

            if (winCount > playCount)
            {
                throw new GameResultArgumentException("winCount cannot be higher than playCount");
            }

            PlayerStrategy = strategy;
            PlayCount = playCount;
            WinCount = winCount;
            ProbabilityOfWinning = (decimal)(PlayCount > 0 ? WinCount * 1.0 / PlayCount : 0);
        }

        public PlayerStrategy PlayerStrategy { get; private set; }
        public int PlayCount { get; private set; }
        public int WinCount { get; private set; }
        public decimal ProbabilityOfWinning { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PlayerStrategy;

            yield return PlayCount;

            yield return WinCount;
        }
    }
}