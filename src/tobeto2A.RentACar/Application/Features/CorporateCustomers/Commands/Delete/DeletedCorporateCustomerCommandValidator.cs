using FluentValidation;

namespace Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommandValidator : AbstractValidator<DeleteCorporateCustomerCommand>
{
    public DeleteCorporateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}