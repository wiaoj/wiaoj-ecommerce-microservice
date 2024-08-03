using Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Exceptions;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CategoryAggregate.ValueObjects;
public readonly record struct CategoryName : IValueObject<CategoryName, String> {
    public const Int32 MinLength = 3;
    public const Int32 MaxLength = 100;
    public String Value { get; }

    private CategoryName(String value) {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        if(value.Length < MinLength)
            throw new CatalogItemNameTooShortException(MinLength);
        if(value.Length > MaxLength)
            throw new CatalogItemNameTooLongException(MaxLength);

        if(!value.All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)))
            throw new CatalogItemNameInvalidCharactersException();

        this.Value = value.Trim();
    }

    public static CategoryName New(String value) {
        return new(value);
    }
}