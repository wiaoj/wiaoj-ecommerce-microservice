namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
public readonly record struct Sku : IValueObject<Sku, String>, INullableValueObject<Sku?, String> {
    public String Value { get; }
    private Sku(String value) {
        this.Value = value;
    }

    public static Sku? NewNullable(String? value) {
        return String.IsNullOrWhiteSpace(value) ? default : new(value);
    }

    public static Sku New(String value) {
        return new(value);
    }
}