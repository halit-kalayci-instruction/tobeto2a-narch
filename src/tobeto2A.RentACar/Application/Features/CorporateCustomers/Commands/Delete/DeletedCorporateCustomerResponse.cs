using NArchitecture.Core.Application.Responses;

namespace Application.Features.CorporateCustomers.Commands.Delete;

public class DeletedCorporateCustomerResponse : IResponse
{
    public Guid Id { get; set; }
}