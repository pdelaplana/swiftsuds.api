namespace SwiftSuds.Domain.Errors;


public record ValidationError(IDictionary<string, string[]> ValidationErrors) 
    : DomainError(ErrorCode.ValidationError, "Validation Failed");
