using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.EntityConfigurations;
internal class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem> {
    public void Configure(EntityTypeBuilder<CatalogItem> builder) {
        builder.ToTable("catalog-items", "catalog-definition");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .IsRequired()
               .ValueGeneratedNever()
               .HasConversion(id => id.Value, value => CatalogItemId.New(value));

        builder.Property(x => x.CategoryId)
               .HasColumnName("catalog_id")
               .IsRequired()
               .ValueGeneratedNever()
               .HasConversion(id => id.Value, value => CategoryId.New(value));

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

        //builder.OwnsOne(x => x.Price, navigationBuilder => {
        //    navigationBuilder.Property(m => m.Currency)
        //         .IsRequired()
        //         .HasMaxLength(3);

        //    navigationBuilder.Property(m => m.Amount)
        //         .IsRequired()
        //         .HasColumnType("decimal(18,2)");
        //});

        builder.Ignore(x => x.Price);
        builder.Ignore(x => x.Images);
        builder.Ignore(x => x.Tags);

        //builder.Metadata.FindNavigation(nameof(CatalogItem.Price))!
        //                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}