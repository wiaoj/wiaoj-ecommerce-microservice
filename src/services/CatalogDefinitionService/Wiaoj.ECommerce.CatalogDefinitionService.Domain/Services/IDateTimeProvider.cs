namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}