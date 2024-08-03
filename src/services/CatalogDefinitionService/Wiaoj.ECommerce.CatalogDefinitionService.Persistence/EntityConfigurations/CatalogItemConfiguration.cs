using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations.ValueConverters;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations;
internal class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem> {
    public void Configure(EntityTypeBuilder<CatalogItem> builder) {
        builder.ToTable("catalog-items", "catalog-definition");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .Id<CatalogItemId, CatalogItemIdConverter>();

        builder.Property(x => x.CategoryId)
               .Id<CategoryId, CategoryIdConverter>("category_id");

        builder.Property(x => x.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(CatalogItemName.MaxLength)
               .HasConversion(name => name.Value, value => CatalogItemName.New(value));

        builder.Property(x => x.Description)
               .HasColumnName("description")
               .IsRequired()
               .HasMaxLength(CatalogItemDescription.MaxLength)
               .HasConversion(name => name.Value, value => CatalogItemDescription.New(value));

        builder.Property(x => x.Sku)
               .HasColumnName("sku")
               .IsRequired()
               .HasMaxLength(150)
               .HasConversion(name => name.Value, value => Sku.New(value));

        builder.Property(x => x.StockQuantity)
               .HasColumnName("stock_quantity")
               .IsRequired()
               .HasConversion(quantity => quantity.Value, value => Quantity.New(value));

        builder.Property(x => x.IsAvailable)
               .HasColumnName("is_available")
               .IsRequired();

        builder.OwnsOne(catalogItem => catalogItem.Price, navigationBuilder => {
            navigationBuilder.WithOwner();

            navigationBuilder.Property(m => m.Currency)
                 .IsRequired()
                 .HasMaxLength(3);

            navigationBuilder.Property(m => m.Amount)
                 .IsRequired()
                 .HasColumnType("decimal(18,2)");

            builder.Metadata.FindNavigation(nameof(CatalogItem.Price))!
                            .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private static Money ConvertToMoney(String value) {
        String[] parts = value.Split(':');
        return Money.New(parts[0], Decimal.Parse(parts[1]));

    }
}