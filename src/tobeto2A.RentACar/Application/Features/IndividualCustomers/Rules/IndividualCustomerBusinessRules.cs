using Application.Features.IndividualCustomers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules : BaseBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly ILocalizationService _localizationService;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository, ILocalizationService localizationService)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, IndividualCustomersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task IndividualCustomerShouldExistWhenSelected(IndividualCustomer? individualCustomer)
    {
        if (individualCustomer == null)
            await throwBusinessException(IndividualCustomersBusinessMessages.IndividualCustomerNotExists);
    }

    public async Task IndividualCustomerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(
            predicate: ic => ic.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await IndividualCustomerShouldExistWhenSelected(individualCustomer);
    }
}