using FluentValidation;
using MontyHall.Application.Commands;

namespace MontyHall.Application.Validations
{
    public class PlayGameCommandValidation : AbstractValidator<PlayGameCommand>
    {
        public PlayGameCommandValidation()
        {
            RuleFor(command => command.NumberOfGamesToPlay)
                .GreaterThan(0)
                .LessThan(10000001); // starts to take time to compute
        }
    }
}