using FluentValidation;

namespace Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommandValidator : AbstractValidator<DeleteIndividualCustomerCommand>
{
    public DeleteIndividualCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}