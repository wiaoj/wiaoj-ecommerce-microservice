using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
internal sealed class CreateCatalogItemCommandHandler(ICatalogItemCreationService creationService,
                                                      ICatalogItemRepository repository)
    : IRequestHandler<CreateCatalogItemCommandRequest, CreateCatalogItemCommandResponse> {
    public async ValueTask<CreateCatalogItemCommandResponse> Handle(CreateCatalogItemCommandRequest request,
                                                              CancellationToken cancellationToken) {
        CatalogItem catalogItem = creationService.CreateCatalogItem(request);
        await repository.InsertAsync(catalogItem, cancellationToken);
        return new(catalogItem.Id);
    }
}