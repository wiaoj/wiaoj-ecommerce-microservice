using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Services;
internal sealed class SystemDateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}