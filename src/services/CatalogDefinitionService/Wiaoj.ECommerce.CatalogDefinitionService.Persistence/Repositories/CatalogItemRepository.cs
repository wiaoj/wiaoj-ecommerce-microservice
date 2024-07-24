using Microsoft.EntityFrameworkCore;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.Repositories;
internal sealed class CatalogItemRepository : ICatalogItemRepository {
    private readonly ICatalogDefinitionDbContext dbContext;

    public CatalogItemRepository(ICatalogDefinitionDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public void Delete(CatalogItem catalogItem) {
        this.dbContext.CatalogItems.Remove(catalogItem);
    }

    public async Task<CatalogItem?> GetByIdAsync(CatalogItemId id, CancellationToken cancellationToken) {
        return await this.dbContext.CatalogItems.AsNoTracking()
                                               .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task InsertAsync(CatalogItem entity, CancellationToken cancellationToken) {
        await this.dbContext.CatalogItems.AddAsync(entity, cancellationToken); 
    }
}