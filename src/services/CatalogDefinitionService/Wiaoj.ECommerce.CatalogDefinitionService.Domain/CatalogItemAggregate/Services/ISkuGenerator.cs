using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
public interface ISkuGenerator {
    Sku Generate(CatalogItemName name, CategoryId categoryId);
}

internal sealed class DefaultSkuGenerator : ISkuGenerator {
    public Sku Generate(CatalogItemName name, CategoryId categoryId) {
        String skuString = $"{ParseCategoryId(categoryId)}-{ParseName(name)}-{ParseRandomize()}".ToUpper();
        return Sku.New(skuString);
    }

    private static ReadOnlySpan<Char> ParseRandomize() {
        return Ulid.NewUlid().ToString().AsSpan()[^8..];
    }

    private static ReadOnlySpan<Char> ParseName(CatalogItemName name) {
        return name.Value.AsSpan()[..3];
    }

    private static ReadOnlySpan<Char> ParseCategoryId(CategoryId categoryId) {
        return categoryId.Value.AsSpan()[..8];
    }
}