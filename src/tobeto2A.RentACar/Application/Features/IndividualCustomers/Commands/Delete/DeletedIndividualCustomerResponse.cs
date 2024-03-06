using NArchitecture.Core.Application.Responses;

namespace Application.Features.IndividualCustomers.Commands.Delete;

public class DeletedIndividualCustomerResponse : IResponse
{
    public Guid Id { get; set; }
}