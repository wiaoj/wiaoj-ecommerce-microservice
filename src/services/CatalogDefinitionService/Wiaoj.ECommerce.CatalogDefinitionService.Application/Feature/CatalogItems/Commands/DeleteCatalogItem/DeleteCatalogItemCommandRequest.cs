using Mediator;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.DeleteCatalogItem;
public sealed record DeleteCatalogItemCommandRequest(String Id) : IRequest;