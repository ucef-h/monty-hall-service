using Core;
using MediatR;
using MontyHall.Domain.MontyPlayerAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MontyHall.Application.Queries
{
    public class GameResultHistoryQuery : IRequest<List<GameResult>>
    {
    }

    public class GameResultHistoryQueryHandler : IRequestHandler<GameResultHistoryQuery, List<GameResult>>
    {
        private readonly IUnitOfWork<MontyPlayer> _unitOfWork;

        public GameResultHistoryQueryHandler(IUnitOfWork<MontyPlayer> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GameResult>> Handle(GameResultHistoryQuery request, CancellationToken cancellationToken)
        {
            var montyPlayers = await _unitOfWork.SelectAllEntitiesAsync();
            var list = montyPlayers
                .Select(montyPlayer => montyPlayer.GameResult())
                .ToList();
            return list;
        }
    }
}