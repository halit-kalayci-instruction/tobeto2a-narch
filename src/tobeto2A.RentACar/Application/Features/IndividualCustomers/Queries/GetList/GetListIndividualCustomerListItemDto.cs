using NArchitecture.Core.Application.Dtos;

namespace Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerListItemDto : IDto
{
    public Guid Id { get; set; }
    public string NationalityId { get; set; }
    public Guid CustomerId { get; set; }
}