using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
public readonly record struct CatalogItemName : IValueObject {
    public String Value { get; }
    private CatalogItemName(String value) {
        this.Value = value;
    }

    public static CatalogItemName New(String value) {
        return new(value);
    }
}