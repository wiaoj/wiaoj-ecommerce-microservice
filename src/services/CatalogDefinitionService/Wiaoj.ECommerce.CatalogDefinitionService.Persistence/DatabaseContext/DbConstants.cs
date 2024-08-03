namespace Wiaoj.ECommerce.CatalogDefinitionService.Persistence.DatabaseContext;
internal static class DbConstants {
    public const String Schema = "catalog-definition";
    public const String CategoryTableName = "catalog-categories";

    public static class CategoryCatalogItemIds {
        public const String TableName = "category-catalog-item-ids";
        public const String ForeignKey = "CategoryId";
    }
}