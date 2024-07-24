using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.CatalogItems.Commands.CreateCatalogItem;
public sealed record CreateCatalogItemCommandRequest(String Name,
                                                     String Description,
                                                     String CategoryId,
                                                     String? Sku,
                                                     String Currency,
                                                     Decimal Price,
                                                     Int16 StockQuantity) : IRequest<CreateCatalogItemCommandResponse>, IHasTransaction;
public sealed record CreateCatalogItemCommandResponse(String Id);