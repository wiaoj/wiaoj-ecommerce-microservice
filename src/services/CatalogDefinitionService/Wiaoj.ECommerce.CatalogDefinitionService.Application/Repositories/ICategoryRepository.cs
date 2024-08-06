using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
public interface ICategoryRepository : IInsertRepository<Category>, IGetByIdRepository<Category, CategoryId>;