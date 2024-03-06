using NArchitecture.Core.Application.Responses;

namespace Application.Features.IndividualCustomers.Commands.Create;

public class CreatedIndividualCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string NationalityId { get; set; }
    public Guid CustomerId { get; set; }
}