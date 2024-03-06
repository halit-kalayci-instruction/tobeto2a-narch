using NArchitecture.Core.Application.Responses;

namespace Application.Features.IndividualCustomers.Commands.Update;

public class UpdatedIndividualCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string NationalityId { get; set; }
    public Guid CustomerId { get; set; }
}