using System.Text;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.ValueObjects;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Services;
public interface ISkuGenerator {
    Sku Generate(CatalogItemName name, CategoryId categoryId);
}

internal sealed class DefaultSkuGenerator : ISkuGenerator {
    public Sku Generate(CatalogItemName name, CategoryId categoryId) {
        String skuString = $"{ParseCategoryId(categoryId)}-{ParseName(name)}-{ParseRandomize()}".ToUpper();
        return Sku.New(skuString);
    }

    private static ReadOnlySpan<Char> ParseRandomize() {
        return Ulid.NewUlid().ToString().AsSpan()[^8..];
    }

    private static ReadOnlySpan<Char> ParseName(CatalogItemName name) {
        return ConvertTurkishCharacters(name.Value.AsSpan()[..3]);
    }

    private static ReadOnlySpan<Char> ParseCategoryId(CategoryId categoryId) {
        return categoryId.Value.AsSpan()[..8];
    }

    private static ReadOnlySpan<Char> ConvertTurkishCharacters(ReadOnlySpan<Char> input) {
        Dictionary<Char, Char> replacements = new() {
        { 'Ç', 'C' }, { 'ç', 'c' },
        { 'Ğ', 'G' }, { 'ğ', 'g' },
        { 'İ', 'I' }, { 'ı', 'i' },
        { 'Ö', 'O' }, { 'ö', 'o' },
        { 'Ş', 'S' }, { 'ş', 's' },
        { 'Ü', 'U' }, { 'ü', 'u' }
    };

        StringBuilder stringBuilder = new(input.Length);

        foreach(Char ch in input) {
            if(replacements.TryGetValue(ch, out Char replacement)) {
                stringBuilder.Append(replacement);
            }
            else {
                stringBuilder.Append(ch);
            }
        }

        return stringBuilder.ToString();
    }
}