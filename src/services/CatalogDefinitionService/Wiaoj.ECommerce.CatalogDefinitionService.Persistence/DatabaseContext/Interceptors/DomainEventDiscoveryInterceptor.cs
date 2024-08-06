using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.Libraries.Domain.Abstractions.DomainEvents;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext.Interceptors;
internal sealed class DomainEventDiscoveryInterceptor : SaveChangesInterceptor {
    private readonly IDomainEventBus domainEventBus;

    public DomainEventDiscoveryInterceptor(IDomainEventBus domainEventBus) {
        this.domainEventBus = domainEventBus;
    }
    public override async ValueTask<InterceptionResult<Int32>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<Int32> result, CancellationToken cancellationToken = default) {
        InterceptionResult<Int32> interceptorResult = await base.SavingChangesAsync(eventData, result, cancellationToken);

        DbContext? dbContext = eventData.Context;

        if(dbContext is null)
            return await ValueTask.FromResult(result);

        if(!interceptorResult.HasResult) {
            IEnumerable<IDomainEvent> domainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvent>()
                                                                            .SelectMany(e => e.Entity.DomainEvents);

            if(domainEvents.Any()) {
                await this.domainEventBus.PublishAsync(domainEvents, cancellationToken);
            }
        }

        return interceptorResult;
    }
}