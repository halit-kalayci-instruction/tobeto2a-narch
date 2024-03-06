using Application.Features.Auth.Rules;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.AuthService;
using Application.Services.Customers;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommand : IRequest<CreatedCorporateCustomerResponse>, ITransactionalRequest
{
    public string TaxNo { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreatedCorporateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly IAuthService _authService;
        private readonly ICustomerService _customerService;

        public CreateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository,
                                         CorporateCustomerBusinessRules corporateCustomerBusinessRules, IAuthService authService, ICustomerService customerService)
        {
            _mapper = mapper;
            _corporateCustomerRepository = corporateCustomerRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _authService = authService;
            _customerService = customerService;
        }

        // Transaction yönetimi
        public async Task<CreatedCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            User user = await _authService.Register(new UserForRegisterDto() { Email=request.Email, Password=request.Password });

            Customer customer = await _customerService.AddAsync(new Customer() 
            { 
                UserId = user.Id, 
                CustomerNo = new Random().Next(1111,9999).ToString()
            });
            
            CorporateCustomer corporateCustomer = _mapper.Map<CorporateCustomer>(request);
            corporateCustomer.CustomerId = customer.Id;

            await _corporateCustomerRepository.AddAsync(corporateCustomer);

            CreatedCorporateCustomerResponse response = _mapper.Map<CreatedCorporateCustomerResponse>(corporateCustomer);
            return response;
        }
    }
}
