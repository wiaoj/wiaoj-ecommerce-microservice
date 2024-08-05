using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.Categories.Commands.CreateCategory;
internal static class Mapper {
    internal static Category CreateCategory(this ICategoryCreationService creationService, CreateCategoryCommandRequest request) {
        CategoryName name = CategoryName.New(request.Name);

        return creationService.Create(name);
    }
}