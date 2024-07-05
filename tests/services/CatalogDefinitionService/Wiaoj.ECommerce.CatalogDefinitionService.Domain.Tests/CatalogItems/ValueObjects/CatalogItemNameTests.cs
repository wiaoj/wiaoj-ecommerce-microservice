using FluentAssertions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.CatalogItems.ValueObjects;
public sealed class CatalogItemNameTests {
    [Fact]
    public void Create_WithValidName_ShouldCreateCatalogItemName() {
        // Arrange
        String validName = "Valid Name";

        // Act
        CatalogItemName catalogItemName = CatalogItemName.New(validName);

        // Assert
        catalogItemName.Value.Should().Be(validName);
    }

    [Fact]
    public void Create_WithEmptyName_ShouldThrowException() {
        // Arrange
        String emptyName = "";

        // Act & Assert
        Func<CatalogItemName> act = () => CatalogItemName.New(emptyName);
        act.Should().ThrowExactly<ArgumentException>();
    }

    // Diğer test metodları...
}