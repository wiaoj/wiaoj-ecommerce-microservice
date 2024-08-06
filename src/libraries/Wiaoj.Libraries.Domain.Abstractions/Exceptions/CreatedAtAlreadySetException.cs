namespace Wiaoj.Libraries.Domain.Abstractions.Exceptions;
public sealed class CreatedAtAlreadySetException() : DomainException("CreatedAt can only be set once.");