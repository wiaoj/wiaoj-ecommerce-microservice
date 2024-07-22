﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext.Interceptors;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.Repositories;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence;
public static class DependencyInjection {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
        services.AddInterceptors();
        services.AddDbContext();
        services.AddRepositories();
        return services;
    }

    private static void AddInterceptors(this IServiceCollection services) {
        services.AddSingleton<CreatableInterceptor>();
        services.AddSingleton<UpdatableInterceptor>();
        services.AddSingleton<DeletableInterceptor>();
    }

    private static void AddDbContext(this IServiceCollection services) {
        services.AddDbContextPool<CatalogDefinitionDbContext>((serviceProvider, options) => {
            options.UseSqlServer("",
                sqlServerOptions => {
                    sqlServerOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)
                    .MigrationsAssembly(typeof(CatalogDefinitionDbContext).Assembly.FullName)
                    .MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: "catalog_definition");
                })
            .AddInterceptors(
                serviceProvider.GetRequiredService<CreatableInterceptor>(),
                serviceProvider.GetRequiredService<UpdatableInterceptor>(),
                serviceProvider.GetRequiredService<DeletableInterceptor>());
        }, poolSize: 1024);
        services.AddScoped<ICatalogDefinitionDbContext, CatalogDefinitionDbContext>();
        services.AddScoped<IUnitOfWork, CatalogDefinitionDbContext>();
    }

    private static void AddRepositories(this IServiceCollection services) {
        services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
    }
}