using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Settings.Configuration;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Events;
using Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                               IConfiguration configuration) {
        services.AddSerilog(configure => {
            configure.ReadFrom.Configuration(configuration, new ConfigurationReaderOptions() {
                SectionName = "Serilog"
            });
        });
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
        services.AddSingleton<IInMemoryMessageQueue, InMemoryMessageQueue>();
        services.AddSingleton<IDomainEventBus, InMemoryDomainEventBus>();
        services.AddHostedService<DomainEventProcessorJob>();
        return services;
    }
}