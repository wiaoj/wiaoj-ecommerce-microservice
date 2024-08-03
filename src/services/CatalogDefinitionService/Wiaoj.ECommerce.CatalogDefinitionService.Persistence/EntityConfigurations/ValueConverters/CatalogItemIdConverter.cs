using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations.ValueConverters;
internal sealed class CatalogItemIdConverter()
    : ValueConverter<CatalogItemId, String>(id => id.Value, value => CatalogItemId.New(value));