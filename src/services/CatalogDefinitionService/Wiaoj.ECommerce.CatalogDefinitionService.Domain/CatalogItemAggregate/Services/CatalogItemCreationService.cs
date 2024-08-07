using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.DomainEvents;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
internal sealed class CatalogItemCreationService : ICatalogItemCreationService {
    private readonly ISkuGenerator skuGenerator;
    private readonly IDateTimeProvider dateTimeProvider;

    public CatalogItemCreationService(ISkuGenerator skuGenerator, IDateTimeProvider dateTimeProvider) {
        this.skuGenerator = skuGenerator;
        this.dateTimeProvider = dateTimeProvider;
    }

    public CatalogItem Create(CatalogItemName name,
                              CatalogItemDescription description,
                              Money price,
                              CategoryId categoryId,
                              Sku? sku,
                              Quantity stockQuantity) {

        CatalogItem catalogItem = new(CatalogItemId.New(),
                                      categoryId,
                                      name,
                                      description,
                                      price,
                                      sku ?? GenerateSku(name, categoryId),
                                      stockQuantity);
        catalogItem.AddDomainEvent(CreateDomainEvent(this.dateTimeProvider, catalogItem.Id, catalogItem.CategoryId));
        return catalogItem;
    }

    private Sku GenerateSku(CatalogItemName name, CategoryId categoryId) {
        return this.skuGenerator.Generate(name, categoryId);
    }

    private CatalogItemCreatedDomainEvent CreateDomainEvent(IDateTimeProvider dateTimeProvider,
                                                            CatalogItemId id,
                                                            CategoryId categoryId) {
        return new(dateTimeProvider.UtcNow) {
            CatalogItemId = id,
            CategoryId = categoryId
        };
    }
}