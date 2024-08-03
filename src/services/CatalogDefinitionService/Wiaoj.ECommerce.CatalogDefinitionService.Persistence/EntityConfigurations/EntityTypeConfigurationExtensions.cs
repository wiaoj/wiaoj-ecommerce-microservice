using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations;
internal static class EntityTypeConfigurationExtensions {
    public static PropertyBuilder<T> Id<T, TConversion>(this PropertyBuilder<T> id) {
        return id.Id<T, TConversion>("id");
    }

    public static PropertyBuilder<T> Id<T, TConversion>(this PropertyBuilder<T> id, String columnName) {
        return id.HasColumnName(columnName)
                 .HasMaxLength(100)
                 .IsRequired(true)
                 .ValueGeneratedNever()
                 .HasConversion<TConversion>();
    }
}