using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.Services;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.Categories.Commands.CreateCategory;
internal sealed class CreateCategoryCommandHandler(ICategoryCreationService creationService,
                                                   ICategoryRepository repository)
    : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse> {
    public async ValueTask<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,
                                                              CancellationToken cancellationToken) {
        Category catalogItem = creationService.CreateCategory(request);
        await repository.InsertAsync(catalogItem, cancellationToken);
        return new(catalogItem.Id);
    }
}