using Wiaoj.ECommerce.CatalogDefinitionService.Domain;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
public interface ICatalogItemRepository
    : IInsertRepository<CatalogItem>,
      IDeleteRepository<CatalogItem>,
      IGetByIdRepository<CatalogItem, CatalogItemId> {
    //Task<CatalogItem> GetByIdAsync(CatalogItemId id);
    //Task<IEnumerable<CatalogItem>> GetAllAsync();
    //Task UpdateAsync(CatalogItem catalogItem);
    //Task DeleteAsync(CatalogItemId id);
}

public interface IInsertRepository<in TEntity> where TEntity : IAggregate {
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
}
public interface IDeleteRepository<in TEntity> where TEntity : IAggregate {
    void Delete(TEntity entity);
}
public interface IGetByIdRepository<TEntity, in TEntityId> where TEntity : IAggregate where TEntityId : IId<TEntityId> {
    Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken);
}