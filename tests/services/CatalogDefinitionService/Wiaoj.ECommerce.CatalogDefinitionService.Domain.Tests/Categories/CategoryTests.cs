using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.TestDatas;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.Categories;
public sealed class CategoryTests {
    [Fact]
    public void AddCatalogItem_Should_Add_Item_To_Category() {
        // Arrange
        Category category = CategoryTestDatas.CreateValidCategory();
        CatalogItemId catalogItemId = CategoryTestDatas.CreateCatalogItemId();

        // Act
        category.AddCatalogItem(catalogItemId);

        // Assert
        category.Items.Should().Contain(catalogItemId);
    }
}