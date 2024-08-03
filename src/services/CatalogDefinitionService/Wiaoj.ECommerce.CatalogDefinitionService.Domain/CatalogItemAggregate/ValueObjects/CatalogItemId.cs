using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
public sealed record CatalogItemId : IId<CatalogItemId> {
    public String Value { get; }

    private CatalogItemId(String value) {
        this.Value = value;
    }

    public static CatalogItemId New() {
        return new(Ulid.NewUlid().ToString());
    }

    public static CatalogItemId New(String value) {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        return !Ulid.TryParse(value, out Ulid _) ? throw new Exception("Id is not valid") : new(value);
    }

    public static implicit operator String(CatalogItemId id) {
        return id.Value;
    }
}