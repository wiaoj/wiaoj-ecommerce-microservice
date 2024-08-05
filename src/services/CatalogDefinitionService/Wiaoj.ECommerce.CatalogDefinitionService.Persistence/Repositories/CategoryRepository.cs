using Microsoft.EntityFrameworkCore;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Repositories;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.Repositories;
internal sealed class CategoryRepository : ICategoryRepository {
    private readonly ICatalogDefinitionDbContext dbContext;

    public CategoryRepository(ICatalogDefinitionDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public async Task InsertAsync(Category entity, CancellationToken cancellationToken) {
        await this.dbContext.Categories.AddAsync(entity, cancellationToken);
    }
}