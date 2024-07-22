using Microsoft.EntityFrameworkCore;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
internal sealed class CatalogDefinitionDbContext : DbContext {
    public DbSet<CatalogItem> CatalogItem { get; internal set; }
}