using FluentValidation;
using FluentValidation.Results;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application;
internal static class ValidatorExtensions
{
    public static async Task<(bool IsValid, ValidationError? ValidationError)> ValidateAndReturnErrorsAsync<T>(this IValidator<T> validator, T request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        return (
            validationResult.IsValid,
            validationResult.IsValid ? new ValidationError(validationResult.ToDictionary()) : null
            );
    }

    
}
