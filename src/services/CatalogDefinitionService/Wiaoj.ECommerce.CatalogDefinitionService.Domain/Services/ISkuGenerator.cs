using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
public interface ISkuGenerator {
    Sku Generate(CatalogItemName name, CategoryId categoryId);
}

internal sealed class DefaultSkuGenerator : ISkuGenerator {
    public Sku Generate(CatalogItemName name, CategoryId categoryId) {
        //TODO: Perhaps I could create an ID generator using ULID.
        String skuString = $"{categoryId.Value}-{name.Value.AsSpan()[..3]}-{Guid.NewGuid().ToString().AsSpan()[..8]}".ToUpper();
        return Sku.New(skuString);
    }
}