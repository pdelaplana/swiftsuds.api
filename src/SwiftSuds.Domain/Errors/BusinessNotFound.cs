namespace SwiftSuds.Domain.Errors;
public record BusinessNotFound() : DomainError(ErrorCode.BusinessNotFound, "Business Not Found");
