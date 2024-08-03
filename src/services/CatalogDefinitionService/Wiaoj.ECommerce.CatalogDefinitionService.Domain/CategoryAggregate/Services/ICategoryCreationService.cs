using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.Services;
public interface ICategoryCreationService {
    Category Create(CategoryName name);
}