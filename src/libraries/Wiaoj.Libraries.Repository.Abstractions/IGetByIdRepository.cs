using Wiaoj.Libraries.Domain.Abstractions;
using Wiaoj.Libraries.Domain.Abstractions.ValueObjects;

namespace Wiaoj.Libraries.Repository.Abstractions;
public interface IGetByIdRepository<TEntity, in TEntityId> where TEntity : Aggregate<TEntityId> where TEntityId : class, IId<TEntityId> {
    Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken);
}