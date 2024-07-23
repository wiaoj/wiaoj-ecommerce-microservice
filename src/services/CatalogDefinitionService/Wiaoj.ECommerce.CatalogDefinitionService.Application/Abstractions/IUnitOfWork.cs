namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
public interface IUnitOfWork {
    Task CreateExecutionStrategyAsync(Func<CancellationToken, Task> operation, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}