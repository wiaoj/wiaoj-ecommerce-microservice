using FluentAssertions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Exceptions;
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

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithNullOrWhiteSpace_ShouldThrowArgumentException(String? value) {
        Func<CatalogItemName> act = () => CatalogItemName.New(value!);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Create_WithTooShortName_ShouldThrowArgumentException() {
        String tooShortName = "Ab";
        Func<CatalogItemName> act = () => CatalogItemName.New(tooShortName);
        act.Should().ThrowExactly<CatalogItemNameTooShortException>();
    }

    [Fact]
    public void Create_WithTooLongName_ShouldThrowArgumentException() {
        String tooLongName = new('A', CatalogItemName.MaxLength + 1);
        Func<CatalogItemName> act = () => CatalogItemName.New(tooLongName);
        act.Should().ThrowExactly<CatalogItemNameTooLongException>();
    }

    [Fact]
    public void Create_WithInvalidCharacters_ShouldThrowArgumentException() {
        String nameWithInvalidChars = "Product Name!@#";
        Func<CatalogItemName> act = () => CatalogItemName.New(nameWithInvalidChars);
        act.Should().ThrowExactly<CatalogItemNameInvalidCharactersException>();
    }

    [Fact]
    public void Create_WithLeadingOrTrailingSpaces_ShouldTrimSpaces() {
        String nameWithSpaces = "  Trimmed Name  ";
        CatalogItemName catalogItemName = CatalogItemName.New(nameWithSpaces);
        catalogItemName.Value.Should().Be("Trimmed Name");
    }
}