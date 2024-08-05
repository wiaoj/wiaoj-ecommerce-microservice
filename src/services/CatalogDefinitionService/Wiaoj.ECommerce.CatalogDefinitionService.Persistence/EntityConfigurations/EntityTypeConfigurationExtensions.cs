using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations;
internal static class EntityTypeConfigurationExtensions {
    public static PropertyBuilder<T> Id<T, TConversion>(this PropertyBuilder<T> id) {
        return id.Id<T, TConversion>("id");
    }

    public static PropertyBuilder<T> Id<T, TConversion>(this PropertyBuilder<T> id, String columnName) {
        return id.HasColumnName(columnName)
                 .HasMaxLength(DbConstants.IdMaxLength)
                 .IsRequired(true)
                 .ValueGeneratedNever()
                 .HasConversion<TConversion>();
    }
}