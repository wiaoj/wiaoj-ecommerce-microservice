using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
internal sealed class CatalogDefinitionDbContext(DbContextOptions<CatalogDefinitionDbContext> options)
    : DbContext(options), ICatalogDefinitionDbContext, IUnitOfWork {
    public DbSet<CatalogItem> CatalogItems => Set<CatalogItem>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public Task CreateExecutionStrategyAsync(Func<CancellationToken, Task> operation, CancellationToken cancellationToken) {
        IExecutionStrategy strategy = this.Database.CreateExecutionStrategy();
        return strategy.ExecuteAsync(operation, cancellationToken);
    }
}