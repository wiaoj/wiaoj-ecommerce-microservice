using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.TestDatas;
internal static class CatalogItemTestDatas {
    public static CatalogItem CreateValidCatalogItem() {
        CatalogItemName name = CatalogItemName.New("Test Item");
        CatalogItemDescription description = CatalogItemDescription.New("Test Description");
        Money money = Money.New("USD", 1);
        CategoryId categoryId = CategoryId.New("");
        Sku sku = Sku.New("TEST-SKU");
        Quantity quantity = Quantity.New(10);

        return new(CatalogItemId.New(),
                   name,
                   description,
                   money,
                   categoryId,
                   sku,
                   quantity);
    }
}