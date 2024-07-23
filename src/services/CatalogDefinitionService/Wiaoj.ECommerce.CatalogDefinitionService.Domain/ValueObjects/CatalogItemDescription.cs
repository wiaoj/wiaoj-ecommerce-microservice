using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
public readonly record struct CatalogItemDescription : IValueObject {
    public const Int32 MinLength = 10;
    public const Int32 MaxLength = 1000;
    public String Value { get; }
    public CatalogItemDescription(String value) {
        this.Value = value;
    }

    public static CatalogItemDescription New(String value) {
        return new(value);
    }
}