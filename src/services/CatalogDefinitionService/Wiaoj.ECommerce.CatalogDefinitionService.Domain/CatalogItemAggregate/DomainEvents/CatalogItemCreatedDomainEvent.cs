using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.Libraries.Domain.Abstractions.DomainEvents;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.DomainEvents;
public sealed record CatalogItemCreatedDomainEvent(DateTimeOffset TimeStampt, Int32 Version) : DomainEvent(TimeStampt, Version) {
    public required CatalogItemId CatalogItemId { get; init; }
    public required CategoryId CategoryId { get; init; }
}