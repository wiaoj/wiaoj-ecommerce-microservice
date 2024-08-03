using Microsoft.Extensions.DependencyInjection;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
        return services;
    }
}