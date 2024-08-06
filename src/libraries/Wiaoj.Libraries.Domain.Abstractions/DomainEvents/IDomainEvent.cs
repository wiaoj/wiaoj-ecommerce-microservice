using Mediator;

namespace Wiaoj.Libraries.Domain.Abstractions.DomainEvents;
public interface IDomainEvent : INotification {
    DomainEventId Id { get; }
    DateTimeOffset TimeStamp { get; }
    Int32 Version { get; }
}