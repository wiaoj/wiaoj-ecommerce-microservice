namespace Wiaoj.Libraries.Domain.Abstractions.DomainEvents;
public abstract record DomainEvent : IDomainEvent {
    public DomainEventId Id { get; }
    public DateTimeOffset TimeStamp { get; }
    public Int32 Version { get; }

    protected DomainEvent(DateTimeOffset timeStampt, Int32 version) {
        this.Id = DomainEventId.New(timeStampt);
        this.TimeStamp = timeStampt;
        this.Version = version;
    }

    public override Int32 GetHashCode() {
        return HashCode.Combine(this.Id, this.TimeStamp, this.Version);
    }
}