using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MontyHall.Application.Commands;
using MontyHall.Application.Queries;
using MontyHall.Application.Responses;
using MontyHall.Domain.MontyPlayerAggregate;
using System.Collections.Generic;

namespace MontyHall.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseBase<GameResult>> PlayGame(int games, bool switchDoor)
        {
            var command = new PlayGameCommand(games, switchDoor);
            var gameResult = await _mediator.Send(command);
            return ResponseBase.SuccessfulResponse(gameResult);
        }
        
        [HttpGet]
        public async Task<ResponseBase<List<GameResult>>> GetResultList()
        {
            var query = new GameResultHistoryQuery();
            var gameResults = await _mediator.Send(query);
            return ResponseBase.SuccessfulResponse(gameResults);
        }
    }
}
