namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Exceptions;
/// <summary>
/// Represents an exception thrown when two Money instances have different currencies.
/// </summary>
/// <remarks>
/// Initializes a new instance of the CurrencyMismatchException class.
/// </remarks>
/// <param name="leftCurrency">The currency of the first Money instance.</param>
/// <param name="rightCurrency">The currency of the second Money instance.</param>
public sealed class CurrencyMismatchException(
    String leftCurrency,
    String rightCurrency)
    : Exception(
        $"Cannot compare Money instances with different currencies: {leftCurrency} and {rightCurrency}.");