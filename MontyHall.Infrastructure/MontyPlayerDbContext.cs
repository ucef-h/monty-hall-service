using Core;
using MediatR;
using MontyHall.Domain.MontyPlayerAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MontyHall.Infrastructure
{
    public class MontyPlayerDbContext : IUnitOfWork<MontyPlayer>
    {
        private readonly IMediator _mediator;
        private readonly IMontyPlayerRepository _montyPlayerRepository;

        public MontyPlayerDbContext(IMediator mediator, IMontyPlayerRepository montyPlayerRepository)
        {
            _mediator = mediator;
            _montyPlayerRepository = montyPlayerRepository;
        }

        public async Task<bool> SaveEntitiesAsync(MontyPlayer entity)
        {
            var isTransient = CheckIsTransient(entity);

            await _mediator.DispatchDomainEventsAsync(entity);

            if (isTransient)
            {
                await _montyPlayerRepository.InsertAsync(entity);
            }
            else
            {
                await _montyPlayerRepository.UpdateAsync(entity);
            }

            return true;
        }

        public async Task<MontyPlayer> SelectEntitiesAsync(string entityId)
        {
            return await _montyPlayerRepository.SelectAsync(entityId);
        }

        public async Task<List<MontyPlayer>> SelectAllEntitiesAsync()
        {
            return await _montyPlayerRepository.SelectAllAsync();
        }

        private bool CheckIsTransient(BaseEntity entity)
        {
            bool isTransient = entity.IsTransient();
            if (isTransient)
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            return isTransient;
        }
    }
}