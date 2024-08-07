using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.CatalogItems.Services;
public sealed class SkuGeneratorTests {
    private readonly ISkuGenerator skuGenerator;

    public SkuGeneratorTests() {
        this.skuGenerator = new DefaultSkuGenerator();
    }

    [Theory]
    [InlineData("TestItem")]
    [InlineData("Tes")]
    public void Generate_ShouldReturnSkuWithExpectedFormat(String catalogItemName) {
        // Arrange
        CategoryId categoryId = CategoryId.New();
        CatalogItemName name = CatalogItemName.New(catalogItemName);

        // Act
        Sku result = this.skuGenerator.Generate(name, categoryId);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNullOrWhiteSpace();

        String[] parts = result.Value.Split('-');
        parts.Should().HaveCount(3);
        parts[0].Should().Be(categoryId.Value[..8]);
        parts[1].Should().Be("TES");
        parts[2].Should().HaveLength(8);
    }

    [Fact]
    public void Generate_ShouldReturnUniqueSku() {
        // Arrange
        CategoryId categoryId = CategoryId.New();
        CatalogItemName name = CatalogItemName.New("TestItem");

        // Act
        Sku result1 = this.skuGenerator.Generate(name, categoryId);
        Sku result2 = this.skuGenerator.Generate(name, categoryId);

        // Assert
        result1.Should().NotBeNull();
        result2.Should().NotBeNull();
        result1.Value.Should().NotBe(result2.Value);
    }
}