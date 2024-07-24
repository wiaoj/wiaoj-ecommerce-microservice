using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Exceptions;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
public readonly record struct CatalogItemName : IValueObject<CatalogItemName, String> {
    public const Int32 MinLength = 3;
    public const Int32 MaxLength = 100;
    public String Value { get; }

    private CatalogItemName(String value) {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        if(value.Length < MinLength)
            throw new CatalogItemNameTooShortException(MinLength);
        if(value.Length > MaxLength)
            throw new CatalogItemNameTooLongException(MaxLength);

        if(!value.All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)))
            throw new CatalogItemNameInvalidCharactersException();

        this.Value = value.Trim();
    }

    /// <summary>
    /// Creates a new CatalogItemName instance.
    /// </summary>
    /// <param name="value">The string value to create the CatalogItemName from.</param>
    /// <returns>A new CatalogItemName instance.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is null or whitespace.</exception>
    /// <exception cref="CatalogItemNameTooShortException">Thrown when <paramref name="value"/> is shorter than the minimum allowed length.</exception>
    /// <exception cref="CatalogItemNameTooLongException">Thrown when <paramref name="value"/> exceeds the maximum allowed length.</exception>
    /// <exception cref="CatalogItemNameInvalidCharactersException">Thrown when <paramref name="value"/> contains characters other than letters, digits, or spaces.</exception>
    public static CatalogItemName New(String value) {
        return new(value);
    }
}