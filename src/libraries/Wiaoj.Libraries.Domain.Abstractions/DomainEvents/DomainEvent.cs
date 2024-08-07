namespace Wiaoj.Libraries.Domain.Abstractions.DomainEvents;
public abstract record DomainEvent : IDomainEvent {
    public DomainEventId Id { get; }
    public DateTimeOffset OccurredAt { get; }
    public Int32 Version { get; }

    protected DomainEvent(DateTimeOffset occurredAt, Int32 version) {
        this.Id = DomainEventId.New(occurredAt);
        this.OccurredAt = occurredAt;
        this.Version = version;
    }

    public override Int32 GetHashCode() {
        return HashCode.Combine(this.Id, this.OccurredAt, this.Version);
    }
}