using Application.Features.CorporateCustomers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules : BaseBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly ILocalizationService _localizationService;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository, ILocalizationService localizationService)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CorporateCustomersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CorporateCustomerShouldExistWhenSelected(CorporateCustomer? corporateCustomer)
    {
        if (corporateCustomer == null)
            await throwBusinessException(CorporateCustomersBusinessMessages.CorporateCustomerNotExists);
    }

    public async Task CorporateCustomerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CorporateCustomerShouldExistWhenSelected(corporateCustomer);
    }
}