using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
public sealed record CatalogItemPrice : IValueObject<CatalogItemPrice, Money> {
    public Money Value { get; set; }

    private CatalogItemPrice(Money value) {
        this.Value = value;
    }

    public static CatalogItemPrice New(Money value) {
        return new(value);
    }
}