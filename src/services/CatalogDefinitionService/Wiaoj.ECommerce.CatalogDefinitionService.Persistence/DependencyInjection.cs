using Microsoft.Extensions.DependencyInjection;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.Repositories;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence;
public static class DependencyInjection {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
        services.AddDbContextPool<CatalogDefinitionDbContext>((serviceProvider, options) => {
            //options.UseSqlServer(configuration.GetConnectionString("MsSQL"),
            //     sqlServerOptions => {
            //         sqlServerOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null);
            //         String? migrationAssemblyName = typeof(ApplicationDbContext).Assembly.GetName().Name;
            //         sqlServerOptions.MigrationsAssembly(migrationAssemblyName)
            //         .MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: "ecommerce");

            //     }).AddInterceptors(serviceProvider.GetRequiredService<TrackableInterceptor>());
        }, poolSize: 1024);
        services.AddScoped<ICatalogDefinitionDbContext, CatalogDefinitionDbContext>();
        services.AddScoped<IUnitOfWork, CatalogDefinitionDbContext>();
        services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
        return services;
    }
}