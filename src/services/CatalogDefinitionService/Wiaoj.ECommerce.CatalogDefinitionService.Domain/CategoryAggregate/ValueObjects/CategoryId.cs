namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
public sealed record CategoryId : IId<CategoryId> {
    public String Value { get; }
    private CategoryId(String value) {
        this.Value = value;
    }

    public static CategoryId New() {
        return new(Ulid.NewUlid().ToString());
    }

    public static CategoryId New(String value) {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        return Ulid.TryParse(value, out Ulid _)
            ? new(value)
            : throw new Exception("Id is not valid");
    }

    public static implicit operator String(CategoryId id) {
        return id.Value;
    }
}