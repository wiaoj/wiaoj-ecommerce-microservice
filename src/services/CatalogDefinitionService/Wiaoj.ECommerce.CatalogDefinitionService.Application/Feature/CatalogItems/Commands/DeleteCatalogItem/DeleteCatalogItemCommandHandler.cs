using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.DeleteCatalogItem;
internal sealed class DeleteCatalogItemCommandHandler(ICatalogItemRepository repository)
    : IRequestHandler<DeleteCatalogItemCommandRequest> {

    public async ValueTask<Unit> Handle(DeleteCatalogItemCommandRequest request, CancellationToken cancellationToken) {
        await repository.DeleteAsync(CatalogItemId.New(request.Id), cancellationToken);
        return Unit.Value;
    }
}