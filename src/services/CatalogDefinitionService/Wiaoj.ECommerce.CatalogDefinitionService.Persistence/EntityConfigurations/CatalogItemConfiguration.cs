using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
using Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations.ValueConverters;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations;
internal class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem> {
    private static class Constants {
        public const String Name = "name";
        public const String Description = "description";
        public const String Sku = "sku";
        public const String StockQuantity = "stock_quantity";
        public const String IsAvailable = "is_available";
        public const String CategoryId = "category_id";
        public const String MoneyColumnType = "decimal(18,2)";
    }
    public void Configure(EntityTypeBuilder<CatalogItem> builder) {
        builder.ToTable(DbConstants.CatalogItemsTableName, DbConstants.Schema);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .Id<CatalogItemId, CatalogItemIdConverter>();

        builder.Property(x => x.CategoryId)
               .Id<CategoryId, CategoryIdConverter>(Constants.CategoryId);

        builder.Property(x => x.Name)
               .HasColumnName(Constants.Name)
               .IsRequired()
               .HasMaxLength(CatalogItemName.MaxLength)
               .HasConversion(name => name.Value, value => CatalogItemName.New(value));

        builder.Property(x => x.Description)
               .HasColumnName(Constants.Description)
               .IsRequired()
               .HasMaxLength(CatalogItemDescription.MaxLength)
               .HasConversion(name => name.Value, value => CatalogItemDescription.New(value));

        builder.Property(x => x.Sku)
               .HasColumnName(Constants.Sku)
               .IsRequired()
               .HasMaxLength(150)
               .HasConversion(name => name.Value, value => Sku.New(value));

        builder.Property(x => x.StockQuantity)
               .HasColumnName(Constants.StockQuantity)
               .IsRequired()
               .HasConversion(quantity => quantity.Value, value => Quantity.New(value));

        builder.Property(x => x.IsAvailable)
               .HasColumnName(Constants.IsAvailable)
               .IsRequired();

        builder.Ignore(x => x.DomainEvents);

        builder.OwnsOne(catalogItem => catalogItem.Price, navigationBuilder => {
            navigationBuilder.WithOwner();

            navigationBuilder.Property(m => m.Currency)
                 .IsRequired()
                 .HasMaxLength(3);

            navigationBuilder.Property(m => m.Amount)
                 .IsRequired()
                 .HasColumnType(Constants.MoneyColumnType);

            builder.Metadata.FindNavigation(nameof(CatalogItem.Price))!
                            .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }
}