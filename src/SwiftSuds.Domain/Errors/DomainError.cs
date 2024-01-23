namespace SwiftSuds.Domain.Errors;

public enum ErrorCode
{
    CustomerNotFound = 100,
    ValidationError = 200,

}
public record DomainError(ErrorCode Code, string Description);