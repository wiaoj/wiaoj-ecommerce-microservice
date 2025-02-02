﻿using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
internal static class Mapper {
    internal static CatalogItem CreateCatalogItem(this ICatalogItemCreationService creationService, CreateCatalogItemCommandRequest request) {
        CatalogItemName name = CatalogItemName.New(request.Name);
        CatalogItemDescription description = CatalogItemDescription.New(request.Description);
        Money price = Money.New(request.Currency, request.Price);
        CategoryId categoryId = CategoryId.New(request.CategoryId);
        Sku? sku = Sku.NewNullable(request.Sku);
        Quantity stockQuantity = Quantity.New(request.StockQuantity);

        return creationService.Create(
            name,
            description,
            price,
            categoryId,
            sku,
            stockQuantity);
    }
}