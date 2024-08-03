using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.DeleteCatalogItem;
internal sealed class DeleteCatalogItemCommandHandler(ICatalogItemRepository repository)
    : IRequestHandler<DeleteCatalogItemCommandRequest> {

    public async ValueTask<Unit> Handle(DeleteCatalogItemCommandRequest request, CancellationToken cancellationToken) {
        CatalogItem? catalogItem = await repository.GetByIdAsync(CatalogItemId.New(request.Id), cancellationToken);

        if(catalogItem is null)
            throw new Exception("Catalog Item not found");

        repository.Delete(catalogItem);
        return Unit.Value;
    }
}