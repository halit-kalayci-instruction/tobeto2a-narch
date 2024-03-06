using NArchitecture.Core.Application.Responses;

namespace Application.Features.CorporateCustomers.Commands.Update;

public class UpdatedCorporateCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string TaxNo { get; set; }
    public Guid CustomerId { get; set; }
}