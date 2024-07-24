namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
public interface IUnitOfWork {
    Task CreateExecutionStrategyAsync(Func<CancellationToken, Task> operation, CancellationToken cancellationToken);
    Task<Int32> SaveChangesAsync(CancellationToken cancellationToken);
}