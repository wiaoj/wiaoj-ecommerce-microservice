using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.DomainEvents;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.Categories.Events;
internal sealed class AddCatalogItemToCategoryDomainEventHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) 
    : INotificationHandler<CatalogItemCreatedDomainEvent> {
    public async ValueTask Handle(CatalogItemCreatedDomainEvent notification, CancellationToken cancellationToken) {
        var category = await repository.GetByIdAsync(notification.CategoryId, cancellationToken);

        if(category is null) {
            throw new Exception("Category not found");
        }

        category.AddCatalogItem(notification.CatalogItemId);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}