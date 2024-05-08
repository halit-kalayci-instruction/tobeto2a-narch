using Application.Services.PaymentService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList;
public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandItemDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly PaymentServiceBase _paymentServiceBase;

        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, IMailService mailService, PaymentServiceBase paymentServiceBase)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _mailService = mailService;
            _paymentServiceBase = paymentServiceBase;
        }

        public async Task<GetListResponse<GetListBrandItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            Mail mail = new Mail(
                subject: "Deneme Maili", 
                textBody: "", 
                htmlBody: "<p> Merhaba <b> Halit </b></p>", // html > text
                new List<MailboxAddress>() { 
                    new("Halit Enes Kalaycı", "halit@kodlama.io")
                });
            await _mailService.SendEmailAsync(mail);

            await _paymentServiceBase.Pay("John Doe", "5406670000000009", "001", 500, DateTime.Now.AddYears(3));

            IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize);

            GetListResponse<GetListBrandItemDto> response = _mapper.Map<GetListResponse<GetListBrandItemDto>>(brands);

            return response;
        }
    }
}
