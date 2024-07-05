namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
public readonly record struct CatalogItemName {
    public String Value { get; }
    public CatalogItemName(String value) {
        this.Value = value;
    }
}