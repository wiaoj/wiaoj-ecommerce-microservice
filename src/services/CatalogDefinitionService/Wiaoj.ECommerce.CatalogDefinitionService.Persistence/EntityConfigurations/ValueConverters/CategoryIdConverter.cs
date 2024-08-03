using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations.ValueConverters;
internal sealed class CategoryIdConverter() 
    : ValueConverter<CategoryId, String>(id => id.Value, value => CategoryId.New(value));