
namespace SwiftSuds.Domain.Errors;

public record CustomerNotFound() : DomainError(ErrorCode.CustomerNotFound, "Customer Not Found");

