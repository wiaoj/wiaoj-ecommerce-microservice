using Mediator;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
public sealed record DeleteCatalogItemCommandRequest(String Id) : IRequest;