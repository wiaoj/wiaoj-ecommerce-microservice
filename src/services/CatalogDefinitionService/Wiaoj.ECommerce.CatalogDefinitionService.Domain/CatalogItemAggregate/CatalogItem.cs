using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
public class CatalogItem : Aggregate<CatalogItemId> {
    public CatalogItemName Name { get; private set; }
    public CatalogItemDescription Description { get; private set; }
    public Money Price { get; private set; }
    public CategoryId CategoryId { get; private set; }
    public Sku Sku { get; private set; }
    public Quantity StockQuantity { get; private set; }
    public Boolean IsAvailable { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CatalogItem() : base() { } // For ORM
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal CatalogItem(CatalogItemId id,
                       CatalogItemName name,
                       CatalogItemDescription description,
                       CatalogItemPrice price,
                       CategoryId categoryId,
                       Sku sku,
                       Quantity stockQuantity) : base(id) {
        this.Name = name;
        this.Description = description;
        this.Price = price.Value;
        this.CategoryId = categoryId;
        this.Sku = sku;
        this.StockQuantity = stockQuantity;
        this.IsAvailable = true;
    }
}