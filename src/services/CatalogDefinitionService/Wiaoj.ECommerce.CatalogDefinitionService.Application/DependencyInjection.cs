using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application;
public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddMediator(options => {
            options.Namespace = typeof(DependencyInjection).Assembly.FullName;
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        services.Scan(_ => {
            _.AddCatalogCreationService();
            _.AddSkuGenerator();
        });

        return services;
    }

    private static void AddSkuGenerator(this ITypeSourceSelector _) {
        _.FromAssemblyOf<ISkuGenerator>()
            .AddClasses(classes => classes.AssignableTo(typeof(ISkuGenerator)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime();
    }

    private static void AddCatalogCreationService(this ITypeSourceSelector _) {
        _.FromAssemblyOf<ICatalogItemCreationService>()
            .AddClasses(classes => classes.AssignableTo(typeof(ICatalogItemCreationService)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime();
    }
}