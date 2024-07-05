using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
public interface ICatalogItemCreationService {
    CatalogItem Create(
        CatalogItemName name,
        CatalogItemDescription description,
        //Money price,
        CategoryId categoryId,
        Sku? sku,
        Quantity stockQuantity);
}