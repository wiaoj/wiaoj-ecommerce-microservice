using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext.Interceptors;
internal sealed class UpdatableInterceptor(IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor {
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                          InterceptionResult<int> result,
                                                                          CancellationToken cancellationToken = default) {
        DbContext? dbContext = eventData.Context;

        if(dbContext is null)
            return ValueTask.FromResult(result);

        var updatableEntries = dbContext.ChangeTracker.Entries<IUpdatable>()
                                        .Where(entry => entry.State == EntityState.Modified);

        foreach(var entry in updatableEntries) {
            entry.Entity.SetUpdatedAt(dateTimeProvider.UtcNow);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}