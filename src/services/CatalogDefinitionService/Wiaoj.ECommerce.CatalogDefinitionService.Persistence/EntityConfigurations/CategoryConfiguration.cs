using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations.ValueConverters;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations;
internal class CategoryConfiguration : IEntityTypeConfiguration<Category> {
    public void Configure(EntityTypeBuilder<Category> builder) {
        builder.ToTable(DbConstants.CategoryTableName, DbConstants.Schema);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .Id<CategoryId, CategoryIdConverter>();

        builder.Property(x => x.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(CategoryName.MaxLength)
               .HasConversion(name => name.Value, value => CategoryName.New(value));

        ConfigureCategoryCatalogItemIdsTable(builder);
    }

    private static void ConfigureCategoryCatalogItemIdsTable(EntityTypeBuilder<Category> builder) {
        builder.OwnsMany(category => category.Items, navigationBuilder => {
            navigationBuilder.ToTable(DbConstants.CategoryCatalogItemIds.TableName, DbConstants.Schema);
            navigationBuilder.HasKey("Id");

            navigationBuilder.WithOwner().HasForeignKey(DbConstants.CategoryCatalogItemIds.ForeignKey);

            navigationBuilder.Property(catalogItemId => catalogItemId.Value)
                .HasColumnName("CatalogItemId")
                .ValueGeneratedNever()
                .IsRequired();
        });

        builder.Metadata.FindNavigation(nameof(Category.Items))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}