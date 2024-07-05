using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
public readonly record struct CatalogItemId : IId {
    public String Value { get; }

    private CatalogItemId(String value) {
        this.Value = value;
    }

    public static CatalogItemId New() {
        return new(Guid.NewGuid().ToString());
    }
}
public readonly record struct CategoryId(Guid Value); 
public readonly record struct Sku(String Value);
public readonly record struct Quantity(Int32 Value);
public readonly record struct ImageUrl(String Url);
public readonly record struct Tag(String Value);
public readonly record struct DiscountPercentage(Decimal Value);