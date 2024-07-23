using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain;
public class CatalogItem : Aggregate<CatalogItemId> {
    public CatalogItemName Name { get; private set; }
    public CatalogItemDescription Description { get; private set; }
    public Money Price { get; private set; }
    public CategoryId CategoryId { get; private set; }
    public Sku Sku { get; private set; }
    public Quantity StockQuantity { get; private set; }
    public Boolean IsAvailable { get; private set; }
    //public DiscountPercentage Discount { get; private set; }
    private readonly List<ImageUrl> images;
    private readonly List<Tag> tags;

    public IReadOnlyCollection<ImageUrl> Images => this.images.AsReadOnly();
    public IReadOnlyCollection<Tag> Tags => this.tags.AsReadOnly();

    private CatalogItem() : base(CatalogItemId.New()){ } // For ORM
    internal CatalogItem(CatalogItemId id,
                       CatalogItemName name,
                       CatalogItemDescription description,
                       Money price,
                       CategoryId categoryId,
                       Sku sku,
                       Quantity stockQuantity) : base(id) {
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.CategoryId = categoryId;
        this.Sku = sku;
        this.StockQuantity = stockQuantity;
        this.IsAvailable = true;
        this.images = [];
        this.tags = [];
    }

    internal void UpdateName(CatalogItemName value) {
        this.Name = value;
    }
    //public void UpdateDetails(CatalogItemName name,
    //                          CatalogItemDescription description,
    //                          //Money price,
    //                          CategoryId categoryId) {
    //    this.Name = name;
    //    this.Description = description;
    //    //this.Price = price;
    //    this.CategoryId = categoryId;
    //}

    //public void UpdateStock(Quantity newQuantity) {
    //    this.StockQuantity = newQuantity;
    //} 

    //public void AddImage(ImageUrl imageUrl) {
    //    this.images.Add(imageUrl);
    //}

    //public void RemoveImage(ImageUrl imageUrl) {
    //    this.images.Remove(imageUrl);
    //}

    //public void AddTag(Tag tag) {
    //    this.tags.Add(tag);
    //}

    //public void RemoveTag(Tag tag) {
    //    this.tags.Remove(tag);
    //}
}