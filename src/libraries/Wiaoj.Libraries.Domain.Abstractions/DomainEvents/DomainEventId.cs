using Wiaoj.Libraries.Domain.Abstractions.ValueObjects;

namespace Wiaoj.Libraries.Domain.Abstractions.DomainEvents;
public sealed record DomainEventId : IValueObject<DomainEventId, DateTimeOffset> {
    public String Value { get; }

    private DomainEventId(Ulid id) {
        this.Value = id.ToString();
    }

    public static DomainEventId New(DateTimeOffset value) {
        return new(Ulid.NewUlid(value));
    }

    public static implicit operator String(DomainEventId id) => id.Value;
}