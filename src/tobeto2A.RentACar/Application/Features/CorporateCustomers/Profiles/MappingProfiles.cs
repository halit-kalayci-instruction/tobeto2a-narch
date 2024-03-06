using Application.Features.CorporateCustomers.Commands.Create;
using Application.Features.CorporateCustomers.Commands.Delete;
using Application.Features.CorporateCustomers.Commands.Update;
using Application.Features.CorporateCustomers.Queries.GetById;
using Application.Features.CorporateCustomers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, CreatedCorporateCustomerResponse>().ReverseMap();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, UpdatedCorporateCustomerResponse>().ReverseMap();
        CreateMap<CorporateCustomer, DeleteCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, DeletedCorporateCustomerResponse>().ReverseMap();
        CreateMap<CorporateCustomer, GetByIdCorporateCustomerResponse>().ReverseMap();
        CreateMap<CorporateCustomer, GetListCorporateCustomerListItemDto>().ReverseMap();
        CreateMap<IPaginate<CorporateCustomer>, GetListResponse<GetListCorporateCustomerListItemDto>>().ReverseMap();
    }
}