using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.Services;
internal class CategoryCreationService : ICategoryCreationService {
    public Category Create(CategoryName name) {
        return new Category(CategoryId.New(), name, []);
    }
}