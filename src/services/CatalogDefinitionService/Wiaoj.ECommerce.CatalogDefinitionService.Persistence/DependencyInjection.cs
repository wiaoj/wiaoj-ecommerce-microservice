using Microsoft.Extensions.DependencyInjection;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.Repositories;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence;
public static class DependencyInjection {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {

        services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
        return services;
    }
}