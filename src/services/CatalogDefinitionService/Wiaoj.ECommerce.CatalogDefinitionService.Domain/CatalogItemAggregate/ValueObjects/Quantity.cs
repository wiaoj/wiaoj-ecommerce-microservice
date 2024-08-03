using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
public readonly record struct Quantity : IValueObject<Quantity, Int16> {
    public Int16 Value { get; }
    private Quantity(Int16 value) {
        this.Value = value;
    }

    public static Quantity New(Int16 value) {
        return new(value);
    }
}