namespace SwiftSuds.Domain.Errors;

public enum ErrorCode
{
    ValidationError = 100,
    CustomerNotFound = 210,
    UserNotFound = 220
}
public record DomainError(ErrorCode Code, string Description);