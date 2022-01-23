using Core;
using MontyHall.Domain.MontyPlayerAggregate;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontyHall.Infrastructure
{
    public class MontyPlayerInMemoryRepository : EntityRepository<MontyPlayer, string>, IMontyPlayerRepository
    {
        private readonly ConcurrentDictionary<string, MontyPlayer> _players;

        public MontyPlayerInMemoryRepository()
        {
            _players = new ConcurrentDictionary<string, MontyPlayer>();
        }

        public async Task InsertAsync(MontyPlayer entity)
        {
            PreInsertEntity(entity);

            _players.TryAdd(entity.Id, entity);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(MontyPlayer entity)
        {
            PreUpdateEntity(entity);

            _players[entity.Id] = entity;
            await Task.CompletedTask;
        }

        public Task<List<MontyPlayer>> SelectAllAsync()
        {
            return Task.FromResult(_players.Values.OrderBy(e => e.CreatedDate).ToList());
        }

        public Task<MontyPlayer> SelectAsync(string entityId)
        {
            _players.TryGetValue(entityId, out var player);
            return Task.FromResult(player);
        }
    }
}