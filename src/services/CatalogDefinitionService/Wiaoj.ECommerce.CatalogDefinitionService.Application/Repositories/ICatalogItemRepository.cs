using Wiaoj.ECommerce.CatalogDefinitionService.Domain;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
public interface ICatalogItemRepository : IInsertRepository<CatalogItem> {
    //Task<CatalogItem> GetByIdAsync(CatalogItemId id);
    //Task<IEnumerable<CatalogItem>> GetAllAsync();
    //Task UpdateAsync(CatalogItem catalogItem);
    //Task DeleteAsync(CatalogItemId id);
}

public interface IInsertRepository<in T> /*where T : IAggregate */{
    Task InsertAsync(T entity, CancellationToken cancellationToken);
}