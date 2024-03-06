using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.IndividualCustomers;

public class IndividualCustomerManager : IIndividualCustomerService
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

    public IndividualCustomerManager(IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules individualCustomerBusinessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _individualCustomerBusinessRules = individualCustomerBusinessRules;
    }

    public async Task<IndividualCustomer?> GetAsync(
        Expression<Func<IndividualCustomer, bool>> predicate,
        Func<IQueryable<IndividualCustomer>, IIncludableQueryable<IndividualCustomer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return individualCustomer;
    }

    public async Task<IPaginate<IndividualCustomer>?> GetListAsync(
        Expression<Func<IndividualCustomer, bool>>? predicate = null,
        Func<IQueryable<IndividualCustomer>, IOrderedQueryable<IndividualCustomer>>? orderBy = null,
        Func<IQueryable<IndividualCustomer>, IIncludableQueryable<IndividualCustomer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<IndividualCustomer> individualCustomerList = await _individualCustomerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return individualCustomerList;
    }

    public async Task<IndividualCustomer> AddAsync(IndividualCustomer individualCustomer)
    {
        IndividualCustomer addedIndividualCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);

        return addedIndividualCustomer;
    }

    public async Task<IndividualCustomer> UpdateAsync(IndividualCustomer individualCustomer)
    {
        IndividualCustomer updatedIndividualCustomer = await _individualCustomerRepository.UpdateAsync(individualCustomer);

        return updatedIndividualCustomer;
    }

    public async Task<IndividualCustomer> DeleteAsync(IndividualCustomer individualCustomer, bool permanent = false)
    {
        IndividualCustomer deletedIndividualCustomer = await _individualCustomerRepository.DeleteAsync(individualCustomer);

        return deletedIndividualCustomer;
    }
}
