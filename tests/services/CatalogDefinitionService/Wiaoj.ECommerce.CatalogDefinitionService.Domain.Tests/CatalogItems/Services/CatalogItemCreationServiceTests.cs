using NSubstitute;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

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

        this.skuGenerator.Generate(name, categoryId).Returns(generatedSku);

        // Act
        CatalogItem catalogItem = this.service.Create(name,
                                                      description,
                                                      money,
                                                      categoryId,
                                                      null,
                                                      quantity);

        // Assert
        catalogItem.Validate(name, description, money, categoryId, generatedSku, quantity);
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
        catalogItem.Validate(name, description, money, categoryId, providedSku, quantity);
        this.skuGenerator
            .DidNotReceive()
            .Generate(Arg.Any<CatalogItemName>(), Arg.Any<CategoryId>());
    }
}