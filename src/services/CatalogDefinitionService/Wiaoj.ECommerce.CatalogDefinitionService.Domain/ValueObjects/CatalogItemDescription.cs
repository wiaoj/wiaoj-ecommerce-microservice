namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
public readonly record struct CatalogItemDescription {
    public String Value { get; }
    public CatalogItemDescription(String value) {
        this.Value = value;
    }
}