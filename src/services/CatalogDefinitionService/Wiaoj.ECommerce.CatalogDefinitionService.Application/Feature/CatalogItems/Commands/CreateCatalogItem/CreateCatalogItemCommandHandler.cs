using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
internal sealed class CreateCatalogItemCommandHandler(ICatalogItemCreationService creationService,
                                                      ICatalogItemRepository repository)
    : IRequestHandler<CreateCatalogItemCommandRequest, CreateCatalogItemCommandResponse> {
    public async ValueTask<CreateCatalogItemCommandResponse> Handle(CreateCatalogItemCommandRequest request,
                                                              CancellationToken cancellationToken) {
        CatalogItem catalogItem = CreateCatalogItem(creationService, request);
        await repository.InsertAsync(catalogItem, cancellationToken);
        return new(catalogItem.Id);
    }

    private static CatalogItem CreateCatalogItem(ICatalogItemCreationService creationService,
                                                 CreateCatalogItemCommandRequest request) {
        CatalogItemName name = CatalogItemName.New(request.Name);
        CatalogItemDescription description = CatalogItemDescription.New(request.Description);
        CategoryId categoryId = CategoryId.New(request.CategoryId);
        Sku? sku = Sku.NewNullable(request.Sku);
        Quantity stockQuantity = Quantity.New(request.StockQuantity);

        return creationService.Create(
            name,
            description,
            //request.Price,
            categoryId,
            sku,
            stockQuantity);
    }
}