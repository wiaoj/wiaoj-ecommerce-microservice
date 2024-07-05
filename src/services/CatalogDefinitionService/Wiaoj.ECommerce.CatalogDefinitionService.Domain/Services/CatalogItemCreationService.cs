using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
internal sealed class CatalogItemCreationService : ICatalogItemCreationService {
    private readonly ISkuGenerator skuGenerator;

    public CatalogItemCreationService(ISkuGenerator skuGenerator) {
        this.skuGenerator = skuGenerator;
    }

    public CatalogItem Create(
        CatalogItemName name,
        CatalogItemDescription description, //Money price,
        CategoryId categoryId, 
        Sku? sku,
        Quantity stockQuantity) {
        return new CatalogItem(
            CatalogItemId.New(),
            name,
            description,
            //price,
            categoryId,
            sku ?? GenerateSku(name, categoryId),
            stockQuantity);
    }

    private Sku GenerateSku(CatalogItemName name, CategoryId categoryId) {
        return skuGenerator.Generate(name, categoryId);
    }
}