using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.Libraries.Repository.Abstractions;
public interface IDeleteRepository<in TEntity> where TEntity : IAggregate {
    void Delete(TEntity entity);
}