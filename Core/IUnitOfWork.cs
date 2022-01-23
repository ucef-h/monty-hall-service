using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork<TBaseEntity> where TBaseEntity : BaseEntity
    {
        Task<bool> SaveEntitiesAsync(TBaseEntity entity);
        Task<TBaseEntity> SelectEntitiesAsync(string entityId);
        Task<List<TBaseEntity>> SelectAllEntitiesAsync();
    }
}