using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
public sealed class CatalogItemCreationService : ICatalogItemCreationService {
    public CatalogItem Create(
        CatalogItemName name,
        CatalogItemDescription description, //Money price,
        CategoryId categoryId, Sku sku,
        Quantity stockQuantity) {
        return new CatalogItem(
            CatalogItemId.New(),
            name,
            description,
            //price,
            categoryId,
            sku,
            stockQuantity);
    }
}