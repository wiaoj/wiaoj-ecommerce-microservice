namespace Wiaoj.Libraries.Domain.Abstractions.Exceptions;
public sealed class EntityAlreadyDeletedException() : DomainException("Entity is already deleted.");