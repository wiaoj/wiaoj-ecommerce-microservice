namespace Wiaoj.Libraries.Domain.Abstractions.DomainEvents;
public interface IHasDomainEvent {
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    void AddDomainEvent(IDomainEvent @event);
    void ClearDomainEvents();
}