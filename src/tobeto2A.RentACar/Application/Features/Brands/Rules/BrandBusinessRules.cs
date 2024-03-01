using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules;
public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }


    public async Task CarShouldNotExistsWithSameName(string name)
    {
        Brand? brandWithSameName = await _brandRepository.GetAsync(b => b.Name == name);

        if (brandWithSameName is not null)
            throw new BusinessException("Aynı isme sahip bir marka zaten mevcut.");
    }
}
