using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wiaoj.Libraries.Domain.Abstractions.DomainEvents;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Events;
internal sealed class DomainEventProcessorJob(IInMemoryMessageQueue inMemoryMessageQueue,
                                              IServiceProvider serviceProvider,
                                              ILogger<DomainEventProcessorJob> logger) : BackgroundService {
    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        logger.LogInformation("DomainEventProcessorJob started.");

        await foreach(IDomainEvent domainEvent in inMemoryMessageQueue.Reader.ReadAllAsync(stoppingToken)) {
            using IServiceScope scope = serviceProvider.CreateScope();
            String eventName = domainEvent.GetType().Name;
            try {
                logger.LogInformation("Processing event: EventType: {EventType}, EventId: {EventId}", eventName, domainEvent.Id);

                IPublisher publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

                await publisher.Publish(domainEvent, stoppingToken);

                logger.LogInformation("Processed event: EventType: {EventType}, EventId: {EventId}", eventName, domainEvent.Id);
            }
            catch(Exception ex) {
                logger.LogError(ex, "Error processing event: EventType: {EventType}, EventId: {EventId}", eventName, domainEvent.Id);
            }
        }

        logger.LogInformation("DomainEventProcessorJob stopped.");
    }
}