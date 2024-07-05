using Wiaoj.ECommerce.CatalogDefinitionService.Domain;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
public interface ICatalogItemRepository
    : IInsertRepository<CatalogItem>,
      IDeleteRepository<CatalogItemId>,
      IGetByIdRepository<CatalogItem, CatalogItemId> {
    //Task<CatalogItem> GetByIdAsync(CatalogItemId id);
    //Task<IEnumerable<CatalogItem>> GetAllAsync();
    //Task UpdateAsync(CatalogItem catalogItem);
    //Task DeleteAsync(CatalogItemId id);
}

public interface IInsertRepository<in TEntity> /*where T : IAggregate */{
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
}
public interface IDeleteRepository<in TEntityId> where TEntityId : IId {
    Task DeleteAsync(TEntityId id, CancellationToken cancellationToken);
}
public interface IGetByIdRepository<TEntity, in TEntityId> /*where T : IAggregate */ where TEntityId : IId {
    Task<TEntity> GetByIdAsync(TEntityId id, CancellationToken cancellationToken);
}