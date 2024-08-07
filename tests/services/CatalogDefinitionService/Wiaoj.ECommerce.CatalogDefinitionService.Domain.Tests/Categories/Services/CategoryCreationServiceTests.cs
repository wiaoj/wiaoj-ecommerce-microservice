using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.Categories.Services;
public sealed class CategoryCreationServiceTests {
    private readonly ICategoryCreationService service;

    public CategoryCreationServiceTests() {
        this.service = new CategoryCreationService();
    }

    [Fact]
    public void Create_WithValidName_ShouldCreateCategoryWithUniqueId() {
        // Arrange
        CategoryName name = CategoryName.New("Test Category");

        // Act
        Category category = this.service.Create(name);

        // Assert
        category.Should().NotBeNull();
        category.Id.Should().NotBeNull();
        category.Id.Value.Should().NotBeEmpty();
        category.Name.Should().Be(name);
        category.Items.Should().BeEmpty();
    }

    [Fact]
    public void Create_ShouldCreateCategoryWithEmptyItems() {
        // Arrange
        CategoryName name = CategoryName.New("Another Category");

        // Act
        Category category = this.service.Create(name);

        // Assert
        category.Should().NotBeNull();
        category.Items.Should().BeEmpty();
    }
}