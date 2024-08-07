namespace Wiaoj.ECommerce.CatalogDefinitionService.Domain.CatalogItemAggregate.Exceptions;
public class CatalogItemNameTooShortException(Int32 minLength)
    : DomainException($"CatalogItemName must be at least {minLength} characters long.");
public class CatalogItemNameTooLongException(Int32 maxLength)
    : DomainException($"CatalogItemName cannot exceed {maxLength} characters.");
public class CatalogItemNameInvalidCharactersException()
    : DomainException("CatalogItemName can only contain letters, digits, and spaces.");