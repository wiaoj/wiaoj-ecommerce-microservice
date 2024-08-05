using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
public sealed record CategoryId : IId<CategoryId> {
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

    public static implicit operator String(CategoryId id) {
        return id.Value;
    }
}