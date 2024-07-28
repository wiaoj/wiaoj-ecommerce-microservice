using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Services;
internal sealed class SystemDateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}