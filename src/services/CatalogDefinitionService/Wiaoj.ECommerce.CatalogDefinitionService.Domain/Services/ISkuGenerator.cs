using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
public interface ISkuGenerator {
    Sku Generate(CatalogItemName name, CategoryId categoryId);
}

internal sealed class DefaultSkuGenerator : ISkuGenerator {
    public Sku Generate(CatalogItemName name, CategoryId categoryId) { 
        String skuString = $"{categoryId.Value}-{name.Value.AsSpan()[..3]}-{Ulid.NewUlid().ToString().AsSpan()[..8]}".ToUpper();
        return Sku.New(skuString);
    }
}