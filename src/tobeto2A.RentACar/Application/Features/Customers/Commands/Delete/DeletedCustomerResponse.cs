using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Commands.Delete;

public class DeletedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
}