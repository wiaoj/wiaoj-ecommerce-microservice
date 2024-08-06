using FluentAssertions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.CatalogItems;
internal static class CatalogItemValidations {
    public static void Validate(
        this CatalogItem catalogItem,
        CatalogItemName name,
        CatalogItemDescription description,
        Money price,
        CategoryId categoryId,
        Sku sku,
        Quantity quantity) {
        catalogItem.Should().NotBeNull();
        catalogItem.Name.Should().NotBeNull().And.Be(name);
        catalogItem.Description.Should().NotBeNull().And.Be(description);
        catalogItem.Price.Should().NotBeNull().And.Be(price);
        catalogItem.CategoryId.Should().NotBeNull().And.Be(categoryId);
        catalogItem.Sku.Should().NotBeNull().And.Be(sku);
        catalogItem.StockQuantity.Should().NotBeNull().And.Be(quantity);
    }
}