using System.Collections.Generic;
using System.Threading.Tasks;

namespace MontyHall.Domain.MontyPlayerAggregate
{
    public interface IMontyPlayerRepository
    {
        Task InsertAsync(MontyPlayer entity);
        Task UpdateAsync(MontyPlayer entity);
        Task<List<MontyPlayer>> SelectAllAsync();
        Task<MontyPlayer> SelectAsync(string entityId);
    }
}