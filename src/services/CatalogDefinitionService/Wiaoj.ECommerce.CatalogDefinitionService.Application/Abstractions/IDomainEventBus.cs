using Wiaoj.Libraries.Domain.Abstractions.DomainEvents;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
public interface IDomainEventBus {
    Task PublishAsync<T>(T domainEvent, CancellationToken cancellationToken) where T : IDomainEvent;
    Task PublishAsync<T>(IEnumerable<T> domainEvents, CancellationToken cancellationToken) where T : IDomainEvent;
}