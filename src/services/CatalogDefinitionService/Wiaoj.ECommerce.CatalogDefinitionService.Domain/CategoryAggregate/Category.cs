using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
public sealed class Category : Aggregate<CategoryId> {
    public CategoryName Name { get; private set; }
    private readonly List<CatalogItemId> items;
    public IReadOnlyCollection<CatalogItemId> Items => this.items.AsReadOnly();
    private Category() : base() { } // For ORM

    internal Category(CategoryId id, CategoryName name, List<CatalogItemId> items) : base(id) {
        this.Name = name;
        this.items = items;
    }
}