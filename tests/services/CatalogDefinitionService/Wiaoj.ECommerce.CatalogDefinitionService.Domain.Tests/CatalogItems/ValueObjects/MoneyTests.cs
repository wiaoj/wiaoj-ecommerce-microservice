using FluentAssertions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.Exceptions;
using Wiaoj.ECommerce.CatalogDefinitionService.Domain.ValueObjects;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.Tests.CatalogItems.ValueObjects;
public sealed class MoneyTests {
    [Fact]
    public void New_ShouldCreateMoneySucceded() {
        // Arrange
        String currency = "USD";

        // Act
        Money money = Money.New(currency, 50);

        // Assert
        money.Currency.Should().Be(currency);
        money.Amount.Should().Be(50);
    }

    [Fact]
    public void Zero_ShouldCreateMoneyWithZeroAmount() {
        // Arrange
        String currency = "USD";

        // Act
        Money money = Money.Zero(currency);

        // Assert
        money.Currency.Should().Be(currency);
        money.Amount.Should().Be(0);
    }

    [Fact]
    public void From_ShouldCreateMoneyWithSameCurrencyAndSpecifiedAmount() {
        // Arrange
        Money originalMoney = Money.New("USD", 10);
        Decimal newAmount = 20;

        // Act
        Money newMoney = Money.From(originalMoney, newAmount);

        // Assert
        newMoney.Currency.Should().Be(originalMoney.Currency);
        newMoney.Amount.Should().Be(newAmount);
    }

    [Fact]
    public void Add_ShouldAddTwoMoneyInstancesWithSameCurrency() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 20);

        // Act
        Money result = money1 + money2;

        // Assert 
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(30);
    }

    [Fact]
    public void Add_ShouldIncreaseAmount_WhenDecimalIsAddedToMoney() {
        // Arrange
        Money money = Money.New("USD", 10);
        Decimal amount = new(20);

        // Act
        Money result = money + amount;

        // Assert 
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(30);
    }

    [Fact]
    public void Add_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("EUR", 20);

        // Act & Assert
        Func<Money> act = () => money1 + money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void Subtract_ShouldSubtractTwoMoneyInstancesWithSameCurrency() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("USD", 10);

        // Act
        Money result = money1 - money2;

        // Assert 
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(10);
    }

    [Fact]
    public void Subtract_ShouldDecreaseAmount_WhenDecimalIsSubtractedFromMoney() {
        // Arrange
        Money money = Money.New("USD", 20);
        Decimal amount = new(10);

        // Act
        Money result = money - amount;

        // Assert 
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(10);
    }

    [Fact]
    public void Subtract_ShouldThrowArgumentOutOfRangeException_WhenResultingAmountIsNegative() {
        // Arrange
        Money money = Money.New("USD", 5);
        Decimal amount = new(10);

        // Act & Assert
        Func<Money> act = () => money - amount;
        act.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Subtract_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("EUR", 10);

        // Act & Assert
        Func<Money> act = () => money1 - money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void Multiply_ShouldMultiplyTwoMoneyInstancesWithSameCurrency() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 2);

        // Act
        Money result = money1 * money2;

        // Assert
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(20);
    }

    [Fact]
    public void Multiply_ShouldMultiplyMoneyInstanceWithDecimal() {
        // Arrange
        Money money = Money.New("USD", 10);
        Decimal multiplier = new(2);

        // Act
        Money result = money * multiplier;

        // Assert
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(20);
    }

    [Fact]
    public void Multiply_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("EUR", 2);

        // Act & Assert
        Func<Money> act = () => money1 * money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void Divide_ShouldDivideTwoMoneyInstancesWithSameCurrency() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 2);

        // Act
        Money result = money1 / money2;

        // Assert
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(5);
    }

    [Fact]
    public void Divide_ShouldDivideMoneyInstanceWithDecimal() {
        // Arrange
        Money money = Money.New("USD", 10);
        Decimal divisor = new(2);

        // Act
        Money result = money / divisor;

        // Assert
        result.Currency.Should().Be("USD");
        result.Amount.Should().Be(5);
    }

    [Fact]
    public void Divide_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("EUR", 2);

        // Act & Assert
        Func<Money> act = () => money1 / money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrue_WhenCurrenciesAndAmountsAreEqual() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 == money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("EUR", 10);

        // Act
        Boolean result = money1 == money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalse_WhenAmountsDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 20);

        // Act
        Boolean result = money1 == money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("EUR", 10);

        // Act
        Boolean result = money1 != money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnTrue_WhenAmountsDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 20);

        // Act
        Boolean result = money1 != money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void InequalityOperator_ShouldReturnFalse_WhenCurrenciesAndAmountsAreEqual() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 != money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOperator_ShouldReturnTrue_WhenFirstAmountIsGreaterThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 > money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GreaterThanOperator_ShouldReturnFalse_WhenFirstAmountIsLessThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 20);

        // Act
        Boolean result = money1 > money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOperator_ShouldReturnFalse_WhenAmountsAreEqual() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 > money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOperator_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("EUR", 10);

        // Act & Assert
        Func<Boolean> act = () => money1 > money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void LessThanOperator_ShouldReturnTrue_WhenFirstAmountIsLessThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 20);

        // Act
        Boolean result = money1 < money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void LessThanOperator_ShouldReturnFalse_WhenFirstAmountIsGreaterThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 < money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void LessThanOperator_ShouldReturnFalse_WhenAmountsAreEqual() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 < money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void LessThanOperator_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("EUR", 20);

        // Act & Assert
        Func<Boolean> act = () => money1 < money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void GreaterThanOrEqualToOperator_ShouldReturnTrue_WhenFirstAmountIsGreaterThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 >= money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GreaterThanOrEqualToOperator_ShouldReturnTrue_WhenAmountsAreEqual() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 >= money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GreaterThanOrEqualToOperator_ShouldReturnFalse_WhenFirstAmountIsLessThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 20);

        // Act
        Boolean result = money1 >= money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GreaterThanOrEqualToOperator_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("EUR", 10);

        // Act & Assert
        Func<Boolean> act = () => money1 >= money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void LessThanOrEqualToOperator_ShouldReturnTrue_WhenFirstAmountIsLessThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 20);

        // Act
        Boolean result = money1 <= money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void LessThanOrEqualToOperator_ShouldReturnTrue_WhenAmountsAreEqual() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 <= money2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void LessThanOrEqualToOperator_ShouldReturnFalse_WhenFirstAmountIsGreaterThanSecond() {
        // Arrange
        Money money1 = Money.New("USD", 20);
        Money money2 = Money.New("USD", 10);

        // Act
        Boolean result = money1 <= money2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void LessThanOrEqualToOperator_ShouldThrowCurrencyMismatchException_WhenCurrenciesDiffer() {
        // Arrange
        Money money1 = Money.New("USD", 10);
        Money money2 = Money.New("EUR", 20);

        // Act & Assert
        Func<Boolean> act = () => money1 <= money2;
        act.Should().ThrowExactly<CurrencyMismatchException>();
    }

    [Fact]
    public void ToString_ShouldReturnCorrectStringRepresentation() {
        // Arrange
        Money money = Money.New("USD", 10);

        // Act
        String result = money.ToString();

        // Assert
        result.Should().Be("10 (USD)");
    }
}