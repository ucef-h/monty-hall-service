using System;

namespace MontyHall.Domain.Exceptions
{
    public class GameResultArgumentException : DomainException
    {
        public GameResultArgumentException(string message) : base(message)
        {
        }
    }
}