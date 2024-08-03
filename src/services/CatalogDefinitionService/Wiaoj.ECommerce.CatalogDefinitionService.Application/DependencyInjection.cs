using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Behaviors;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application;
public static class DependencyInjection {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddMediator(options => {
            options.Namespace = "Wiaoj.ECommerce.CatalogDefinitionService.Application";
            options.ServiceLifetime = ServiceLifetime.Transient;
        });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        services.Scan(_ => {
            _.AddCreationService<ICatalogItemCreationService>(); 
            _.AddCreationService<ICategoryCreationService>(); 
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

    private static void AddCreationService<TCreationService>(this ITypeSourceSelector _) {
        _.FromAssemblyOf<TCreationService>()
            .AddClasses(classes => classes.AssignableTo(typeof(TCreationService)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime();
    }
}