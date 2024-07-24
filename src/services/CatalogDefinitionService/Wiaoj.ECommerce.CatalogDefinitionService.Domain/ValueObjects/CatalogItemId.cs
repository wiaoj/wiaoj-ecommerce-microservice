using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
public readonly record struct CatalogItemId : IId<CatalogItemId> {
    public String Value { get; }

    private CatalogItemId(String value) {
        this.Value = value;
    }

    public static CatalogItemId New() {
        return new(Ulid.NewUlid().ToString());
    }

    public static CatalogItemId New(String value) {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if(!Ulid.TryParse(value, out var _))
            throw new Exception("Id is not valid");

        return new(value);
    }

    public static implicit operator String(CatalogItemId id) {
        return id.Value;
    }
}
public readonly record struct CategoryId : IId<CategoryId> {
    public String Value { get; }
    private CategoryId(String value) {
        this.Value = value;
    }

    public static CategoryId New(String value) {
        return new(value);
    }

    public static CategoryId New() {
        return new(Guid.NewGuid().ToString());
    }
}
public readonly record struct Sku : IValueObject<Sku, String> {
    public String Value { get; }
    private Sku(String value) {
        this.Value = value;
    }

    public static Sku? NewNullable(String? value) {
        if(String.IsNullOrWhiteSpace(value)) {
            return default;
        }
        return new(value);
    }

    public static Sku New(String value) {
        return new(value);
    }
}
public readonly record struct Quantity : IValueObject<Quantity, Int16> {
    public Int16 Value { get; }
    private Quantity(Int16 value) {
        this.Value = value;
    }

    public static Quantity New(Int16 value) {
        return new(value);
    }
}
public readonly record struct ImageUrl(String Url);
public readonly record struct Tag(String Value);
public readonly record struct DiscountPercentage(Decimal Value);