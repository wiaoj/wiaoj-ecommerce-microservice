using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
internal sealed class CatalogDefinitionDbContext(DbContextOptions options) : DbContext(options), ICatalogDefinitionDbContext, IUnitOfWork {
    public DbSet<CatalogItem> CatalogItem => Set<CatalogItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public Task CreateExecutionStrategyAsync(Func<CancellationToken, Task> operation, CancellationToken cancellationToken) {
        IExecutionStrategy strategy = this.Database.CreateExecutionStrategy();
        return strategy.ExecuteAsync(operation, cancellationToken);
    }

    Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken) {
        return SaveChangesAsync(cancellationToken);
    }
}