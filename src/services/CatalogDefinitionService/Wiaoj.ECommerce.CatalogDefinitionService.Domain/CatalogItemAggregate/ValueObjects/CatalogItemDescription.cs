namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
public readonly record struct CatalogItemDescription : IValueObject<CatalogItemDescription, String> {
    public const Int32 MinLength = 10;
    public const Int32 MaxLength = 1000;
    public String Value { get; }

    private CatalogItemDescription(String value) {
        this.Value = value;
    }

    public static CatalogItemDescription New(String value) {
        return new(value);
    }
}