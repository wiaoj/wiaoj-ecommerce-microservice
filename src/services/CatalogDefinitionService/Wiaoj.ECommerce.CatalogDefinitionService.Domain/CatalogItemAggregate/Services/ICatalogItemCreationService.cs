using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
public interface ICatalogItemCreationService {
    CatalogItem Create(CatalogItemName name,
                       CatalogItemDescription description,
                       Money price,
                       CategoryId categoryId,
                       Sku? sku,
                       Quantity stockQuantity);
}