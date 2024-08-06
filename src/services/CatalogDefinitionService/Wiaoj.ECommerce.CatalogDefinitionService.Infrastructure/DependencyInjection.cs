using Microsoft.Extensions.DependencyInjection;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Events;
using Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
        services.AddSingleton<IInMemoryMessageQueue, InMemoryMessageQueue>();
        services.AddSingleton<IDomainEventBus, InMemoryDomainEventBus>();
        services.AddHostedService<DomainEventProcessorJob>();
        return services;
    }
}