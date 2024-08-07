using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.CatalogItems;
public sealed class CatalogItemTests {
    [Fact]
    public void Create_WithValidInputs_ShouldCreateCatalogItem() {
        // Arrange
        CatalogItemName name = CatalogItemName.New("Test Item");
        CatalogItemDescription description = CatalogItemDescription.New("Test Description");
        Money price = Money.New("USD", 1);
        CategoryId categoryId = CategoryId.New();
        Sku sku = Sku.New("TEST-SKU");
        Quantity quantity = Quantity.New(10);

        // Act
        CatalogItem catalogItem = new(
            CatalogItemId.New(),
            categoryId,
            name,
            description,
            price,
            sku,
            quantity);

        // Assert
        catalogItem.Validate(name, description, price, categoryId, sku, quantity);
    }
}