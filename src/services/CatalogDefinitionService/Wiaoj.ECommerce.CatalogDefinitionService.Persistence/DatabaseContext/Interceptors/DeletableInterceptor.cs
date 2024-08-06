using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext.Interceptors;
internal sealed class DeletableInterceptor(IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor {
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                          InterceptionResult<int> result,
                                                                          CancellationToken cancellationToken = default) {
        DbContext? dbContext = eventData.Context;

        if(dbContext is null)
            return ValueTask.FromResult(result);

        var deletableEntries = dbContext.ChangeTracker.Entries<IDeletable>()
                                                      .Where(entry => entry.State is EntityState.Deleted);

        foreach(var entry in deletableEntries) {
            entry.State = EntityState.Modified;
            entry.Entity.Delete(dateTimeProvider.UtcNow);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}