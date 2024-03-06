using FluentValidation;

namespace Application.Features.CorporateCustomers.Commands.Update;

public class UpdateCorporateCustomerCommandValidator : AbstractValidator<UpdateCorporateCustomerCommand>
{
    public UpdateCorporateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TaxNo).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}