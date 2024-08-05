namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
internal static class DbConstants {
    public const String Schema = "catalog-definition";
    public const String CatalogItemsTableName = "catalog-items";
    public const String CategoriesTableName = "catalog-categories";
    public const Byte IdMaxLength = 100;

    public static class CategoryCatalogItemIds {
        public const String TableName = "category-catalog-item-ids";
        public const String ForeignKey = "CategoryId";
    }
}