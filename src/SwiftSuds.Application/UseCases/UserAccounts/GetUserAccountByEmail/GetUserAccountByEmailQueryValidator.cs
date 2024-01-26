using FluentValidation;

namespace SwiftSuds.Application.UseCases.UserAccounts.GetUserAccountByEmail;
internal class GetUserAccountByEmailQueryValidator : AbstractValidator<GetUserAccountByEmailQuery>
{
    public GetUserAccountByEmailQueryValidator()
    {
        RuleFor(model => model.Email).EmailAddress();
    }
}
