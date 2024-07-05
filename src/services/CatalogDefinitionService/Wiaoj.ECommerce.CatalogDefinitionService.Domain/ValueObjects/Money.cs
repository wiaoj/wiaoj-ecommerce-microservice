using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Exceptions;
using Wiaoj.Libraries.Domain.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;
/// <summary>
/// Represents a monetary value with its associated currency.
/// </summary>
public readonly record struct Money : IValueObject,
    IAdditionOperators<Money, Money, Money>,
    IAdditionOperators<Money, Decimal, Money>,
    ISubtractionOperators<Money, Money, Money>,
    ISubtractionOperators<Money, Decimal, Money>, 
    IMultiplyOperators<Money, Money, Money>,
    IMultiplyOperators<Money, Decimal, Money>, 
    IDivisionOperators<Money, Money, Money>,
    IDivisionOperators<Money, Decimal, Money>, 
    IComparisonOperators<Money, Money, Boolean> {
    public String Currency { get; }
    public Decimal Amount { get; }

    private Money(String currency, Decimal amount) {
        ArgumentException.ThrowIfNullOrWhiteSpace(currency);
        ArgumentNullException.ThrowIfNull(amount);
        ArgumentOutOfRangeException.ThrowIfLessThan(amount, 0);
        this.Currency = currency;
        this.Amount = amount;
    }

    public static Money New(String currency, Decimal amount) {
        return new(currency, amount);
    }

    /// <summary>
    /// Creates a new Money instance with a zero amount and the specified currency.
    /// </summary>
    /// <param name="currency">The currency of the money.</param>
    /// <returns>A Money instance with a zero amount and the specified currency.</returns>
    public static Money Zero(String currency) {
        return new(currency, 0);
    }

    /// <summary>
    /// Creates a new Money instance with the same currency as the provided money instance and the specified amount.
    /// </summary>
    /// <param name="money">The Money instance to use the currency from.</param>
    /// <param name="amount">The new amount for the Money instance.</param>
    /// <returns>A new Money instance with the same currency as the provided money instance and the specified amount.</returns>
    public static Money From(Money money, Decimal amount) {
        return new(money.Currency, amount);
    }

    /// <summary>
    /// Adds two Money instances together.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>A new Money instance representing the sum of the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator +(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return new(left.Currency, left.Amount + right.Amount);
    }

    /// <summary>
    /// Adds two Money instances together.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="rightAmount">The second amount</param>
    /// <returns>A new Money instance representing the sum of the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator +(Money left, Decimal rightAmount) {
        return new(left.Currency, left.Amount + rightAmount);
    }

    /// <summary>
    /// Subtracts one Money instance from another.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>A new Money instance representing the difference between the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator -(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return new(left.Currency, left.Amount - right.Amount);
    }

    /// <summary>
    /// Adds two Money instances together.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="rightAmount">The second amount</param>
    /// <returns>A new Money instance representing the sum of the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator -(Money left, Decimal rightAmount) {
        return new(left.Currency, left.Amount - rightAmount);
    }

    /// <summary>
    /// Multiplies two Money instances.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>A new Money instance representing the product of the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator *(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return new(left.Currency, left.Amount * right.Amount);
    }

    /// <summary>
    /// Adds two Money instances together.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="rightAmount">The second amount</param>
    /// <returns>A new Money instance representing the sum of the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator *(Money left, Decimal rightAmount) {
        return new(left.Currency, left.Amount * rightAmount);
    }

    /// <summary>
    /// Divides one Money instance by another.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>A new Money instance representing the quotient of the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator /(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return new(left.Currency, left.Amount / right.Amount);
    }

    /// <summary>
    /// Adds two Money instances together.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="rightAmount">The second amount</param>
    /// <returns>A new Money instance representing the sum of the two Money instances.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Money operator /(Money left, Decimal rightAmount) {
        return new(left.Currency, left.Amount / rightAmount);
    }

    /// <summary>
    /// Compares two Money instances for greater than.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>True if the first Money instance is greater than the second Money instance; otherwise, false.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Boolean operator >(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return left.Amount > right.Amount;
    }

    /// <summary>
    /// Compares two Money instances for less than.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>True if the first Money instance is less than the second Money instance; otherwise, false.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Boolean operator <(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return left.Amount < right.Amount;
    }

    /// <summary>
    /// Compares two Money instances for greater than or equal to.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>True if the first Money instance is greater than or equal to the second Money instance; otherwise, false.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Boolean operator >=(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return left.Amount >= right.Amount;
    }

    /// <summary>
    /// Compares two Money instances for less than or equal to.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <returns>True if the first Money instance is less than or equal to the second Money instance; otherwise, false.</returns>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    public static Boolean operator <=(Money left, Money right) {
        ThrowIfDifferentCurrencies(left, right);
        return left.Amount <= right.Amount;
    }

    /// <summary>
    /// Returns a string representation of the Money instance.
    /// </summary>
    /// <returns>A string representation of the Money instance in the format "Amount - Currency".</returns>
    public override String ToString() {
        return $"{this.Amount} ({this.Currency})";
    }

    /// <summary>
    /// Throws a CurrencyMismatchException if the two Money instances have different currencies.
    /// </summary>
    /// <param name="left">The first Money instance.</param>
    /// <param name="right">The second Money instance.</param>
    /// <exception cref="CurrencyMismatchException">Thrown if the two Money instances have different currencies.</exception>
    private static void ThrowIfDifferentCurrencies(Money left, Money right) {
        if(left.Currency != right.Currency)
            throw new CurrencyMismatchException(left.Currency, right.Currency);
    }
}