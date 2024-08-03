using Microsoft.EntityFrameworkCore;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
public interface ICatalogDefinitionDbContext {
    DbSet<CatalogItem> CatalogItems { get; }
    DbSet<Category> Categories { get; }
}