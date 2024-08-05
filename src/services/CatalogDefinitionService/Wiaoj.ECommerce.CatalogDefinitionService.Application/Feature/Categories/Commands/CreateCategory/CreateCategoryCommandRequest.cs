using Mediator;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Feature.Categories.Commands.CreateCategory;
public sealed record CreateCategoryCommandRequest(String Name) : IRequest<CreateCategoryCommandResponse>, IHasTransaction;
public sealed record CreateCategoryCommandResponse(String Id);