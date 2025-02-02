﻿using NSubstitute;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.DomainEvents;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.CatalogItems.Services;
public sealed class CatalogItemCreationServiceTests {
    private readonly ICatalogItemCreationService service;
    private readonly ISkuGenerator skuGenerator;
    private readonly IDateTimeProvider dateTimeProvider;

    public CatalogItemCreationServiceTests() {
        this.skuGenerator = Substitute.For<ISkuGenerator>();
        this.dateTimeProvider = Substitute.For<IDateTimeProvider>();
        this.service = new CatalogItemCreationService(this.skuGenerator, this.dateTimeProvider);
    }

    [Fact]
    public void Create_WithNullSku_ShouldGenerateSkuAndCreateCatalogItem() {
        // Arrange
        CatalogItemName name = CatalogItemName.New("Test Item");
        CatalogItemDescription description = CatalogItemDescription.New("Test Description");
        Money money = Money.Zero("TEST");
        CategoryId categoryId = CategoryId.New(String.Empty);
        Sku generatedSku = Sku.New("GENERATED-SKU");
        Quantity quantity = Quantity.New(10);

        DateTime dateTime = new(2024, 5, 19, 0, 0, 0, DateTimeKind.Utc);
        this.skuGenerator.Generate(name, categoryId).Returns(generatedSku);
        this.dateTimeProvider.UtcNow.Returns(dateTime);

        // Act
        CatalogItem catalogItem = this.service.Create(name,
                                                      description,
                                                      money,
                                                      categoryId,
                                                      null,
                                                      quantity);

        // Assert
        ValidateCatalogItem(catalogItem, name, description, money, categoryId, generatedSku, quantity);
        this.skuGenerator.Received(1).Generate(name, categoryId);
    }

    [Fact]
    public void Create_WithProvidedSku_ShouldUseThatSkuAndCreateCatalogItem() {
        // Arrange
        CatalogItemName name = CatalogItemName.New("Test Item");
        CatalogItemDescription description = CatalogItemDescription.New("Test Description");
        Money money = Money.Zero("TEST");
        CategoryId categoryId = CategoryId.New(String.Empty);
        Sku providedSku = Sku.New("PROVIDED-SKU");
        Quantity quantity = Quantity.New(10);

        // Act
        CatalogItem catalogItem = this.service.Create(name,
                                                      description,
                                                      money,
                                                      categoryId,
                                                      providedSku,
                                                      quantity);

        // Assert
        ValidateCatalogItem(catalogItem, name, description, money, categoryId, providedSku, quantity);
        this.skuGenerator
            .DidNotReceive()
            .Generate(Arg.Any<CatalogItemName>(), Arg.Any<CategoryId>());
    }

    private static void ValidateCatalogItem(CatalogItem catalogItem,
                                            CatalogItemName name,
                                            CatalogItemDescription description,
                                            Money money,
                                            CategoryId categoryId,
                                            Sku providedSku,
                                            Quantity quantity) {
        catalogItem.Validate(name, description, money, categoryId, providedSku, quantity);
        catalogItem.DomainEvents.Should().ContainSingle();
        catalogItem.DomainEvents.Should().ContainItemsAssignableTo<CatalogItemCreatedDomainEvent>();
    }
}