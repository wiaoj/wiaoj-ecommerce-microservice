namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Exceptions;
public class CatalogItemNameTooShortException(int minLength)
    : DomainException($"CatalogItemName must be at least {minLength} characters long.");
public class CatalogItemNameTooLongException(int maxLength)
    : DomainException($"CatalogItemName cannot exceed {maxLength} characters.");
public class CatalogItemNameInvalidCharactersException()
    : DomainException("CatalogItemName can only contain letters, digits, and spaces.");