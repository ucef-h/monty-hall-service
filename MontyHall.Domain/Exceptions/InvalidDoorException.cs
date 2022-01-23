using System;


namespace MontyHall.Domain.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class InvalidDoorException : DomainException
    {
        public InvalidDoorException(int index) : base($"Door Number should be greater than or equal to 2, Input: {index} ")
        {
        }
    }
}