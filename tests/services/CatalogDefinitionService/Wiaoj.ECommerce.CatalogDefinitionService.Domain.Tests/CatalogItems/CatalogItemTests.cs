using FluentAssertions;
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
        Money money = Money.New("USD", 1);
        CategoryId categoryId = CategoryId.New("");
        Sku sku = Sku.New("TEST-SKU");
        Quantity quantity = Quantity.New(10);

        // Act
        CatalogItem catalogItem = new(
            CatalogItemId.New(),
            name,
            description,
            money,
            categoryId,
            sku,
            quantity);

        // Assert
        catalogItem.Should().NotBeNull();
        name.Should().Be(catalogItem.Name);
        description.Should().Be(catalogItem.Description);
        money.Should().Be(catalogItem.Price);
        categoryId.Should().Be(catalogItem.CategoryId);
        sku.Should().Be(catalogItem.Sku);
        quantity.Should().Be(catalogItem.StockQuantity);
    }
}