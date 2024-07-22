using Microsoft.EntityFrameworkCore;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
public interface ICatalogDefinitionDbContext {
    DbSet<CatalogItem> CatalogItem { get; }
}