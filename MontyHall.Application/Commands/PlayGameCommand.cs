using Core;
using MediatR;
using MontyHall.Domain.MontyPlayerAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace MontyHall.Application.Commands
{
    public class PlayGameCommand : IRequest<GameResult>
    {
        public int NumberOfGamesToPlay { get; }
        public bool ShouldSwitchDoors { get; }

        public PlayGameCommand(int numberOfGamesToPlay, bool shouldSwitchDoors)
        {
            NumberOfGamesToPlay = numberOfGamesToPlay;
            ShouldSwitchDoors = shouldSwitchDoors;
        }
    }

    public class PlayGameCommandHandler : IRequestHandler<PlayGameCommand, GameResult>
    {
        private readonly IUnitOfWork<MontyPlayer> _unitOfWork;

        public PlayGameCommandHandler(IUnitOfWork<MontyPlayer> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GameResult> Handle(PlayGameCommand request, CancellationToken cancellationToken)
        {
            var player = new MontyPlayer(PlayerStrategy.Create(request.ShouldSwitchDoors));
            player.Play(request.NumberOfGamesToPlay);

            await _unitOfWork.SaveEntitiesAsync(player);

            return player.GameResult();
        }
    }
}