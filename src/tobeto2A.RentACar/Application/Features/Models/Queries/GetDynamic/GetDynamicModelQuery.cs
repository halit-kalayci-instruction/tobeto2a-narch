using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetDynamic;
public class GetDynamicModelQuery : IRequest<GetListResponse<GetDynamicModelItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }

    public class GetDynamicModelQueryHandler : IRequestHandler<GetDynamicModelQuery, GetListResponse<GetDynamicModelItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicModelItemDto>> Handle(GetDynamicModelQuery request, CancellationToken cancellationToken)
        {
            var models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, include: i=>i.Include(i=>i.Brand));

            GetListResponse<GetDynamicModelItemDto> response = _mapper.Map<GetListResponse<GetDynamicModelItemDto>>(models);

            return response;
        }
    }
}
