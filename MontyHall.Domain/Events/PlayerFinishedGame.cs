using Core;

namespace MontyHall.Domain.Events
{
    public class PlayerFinishedGame : DomainEvent
    {
        public int WinCount { get; }
        public int PlayCount { get; }

        public PlayerFinishedGame(int winCount, int playCount)
        {
            WinCount = winCount;
            PlayCount = playCount;
        }
    }
}