using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
internal sealed class CreateCatalogItemCommandHandler(ICatalogItemCreationService creationService,
                                                      ICatalogItemRepository repository,
                                                      ICategoryRepository categoryRepository)
    : IRequestHandler<CreateCatalogItemCommandRequest, CreateCatalogItemCommandResponse> {
    public async ValueTask<CreateCatalogItemCommandResponse> Handle(CreateCatalogItemCommandRequest request,
                                                              CancellationToken cancellationToken) {
        await CheckCategory(categoryRepository, request, cancellationToken);

        CatalogItem catalogItem = creationService.CreateCatalogItem(request);
        await repository.InsertAsync(catalogItem, cancellationToken);
        return new(catalogItem.Id);
    }

    private static async Task CheckCategory(ICategoryRepository categoryRepository,
                                            CreateCatalogItemCommandRequest request,
                                            CancellationToken cancellationToken) {
        Category? category = await categoryRepository.GetByIdAsync(CategoryId.New(request.CategoryId), cancellationToken);

        if(category is null) {
            throw new Exception("Category Not Found..");
        }
    }
}