using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.Libraries.Repository.Abstractions;

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