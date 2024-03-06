using NArchitecture.Core.Application.Responses;

namespace Application.Features.CorporateCustomers.Queries.GetById;

public class GetByIdCorporateCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string TaxNo { get; set; }
    public Guid CustomerId { get; set; }
}