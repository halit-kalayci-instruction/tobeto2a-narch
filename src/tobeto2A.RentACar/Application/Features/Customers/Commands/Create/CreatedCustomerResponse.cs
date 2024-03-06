using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Commands.Create;

public class CreatedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string? CustomerNo { get; set; }
    public Guid UserId { get; set; }
}