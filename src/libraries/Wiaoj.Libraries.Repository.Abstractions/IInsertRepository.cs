using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.Libraries.Repository.Abstractions;
public interface IInsertRepository<in TEntity> where TEntity : IAggregate {
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
}