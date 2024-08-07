using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.TestDatas;
internal static class CategoryTestDatas {
    public static Category CreateValidCategory() {
        CategoryName name = CategoryName.New("Test Category");
        List<CatalogItemId> items = [];

        return new(CategoryId.New(),
                   name,
                   items);
    }

    public static CatalogItemId CreateCatalogItemId() {
        return CatalogItemId.New();
    }
}
