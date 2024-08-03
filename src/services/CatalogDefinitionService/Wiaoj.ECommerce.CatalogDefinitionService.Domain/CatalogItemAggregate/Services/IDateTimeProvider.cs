namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}