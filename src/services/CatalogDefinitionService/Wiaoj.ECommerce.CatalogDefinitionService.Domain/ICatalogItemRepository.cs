using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain;
public interface ICatalogItemRepository : IInsertRepository<CatalogItem> {
    //Task<CatalogItem> GetByIdAsync(CatalogItemId id);
    //Task<IEnumerable<CatalogItem>> GetAllAsync();
    //Task UpdateAsync(CatalogItem catalogItem);
    //Task DeleteAsync(CatalogItemId id);
}

public interface IInsertRepository<in T> /*where T : IAggregate */{
    Task InsertAsync(T entity);
}