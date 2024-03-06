using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CorporateCustomers;

public class CorporateCustomerManager : ICorporateCustomerService
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

    public CorporateCustomerManager(ICorporateCustomerRepository corporateCustomerRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
    }

    public async Task<CorporateCustomer?> GetAsync(
        Expression<Func<CorporateCustomer, bool>> predicate,
        Func<IQueryable<CorporateCustomer>, IIncludableQueryable<CorporateCustomer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return corporateCustomer;
    }

    public async Task<IPaginate<CorporateCustomer>?> GetListAsync(
        Expression<Func<CorporateCustomer, bool>>? predicate = null,
        Func<IQueryable<CorporateCustomer>, IOrderedQueryable<CorporateCustomer>>? orderBy = null,
        Func<IQueryable<CorporateCustomer>, IIncludableQueryable<CorporateCustomer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CorporateCustomer> corporateCustomerList = await _corporateCustomerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return corporateCustomerList;
    }

    public async Task<CorporateCustomer> AddAsync(CorporateCustomer corporateCustomer)
    {
        CorporateCustomer addedCorporateCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer);

        return addedCorporateCustomer;
    }

    public async Task<CorporateCustomer> UpdateAsync(CorporateCustomer corporateCustomer)
    {
        CorporateCustomer updatedCorporateCustomer = await _corporateCustomerRepository.UpdateAsync(corporateCustomer);

        return updatedCorporateCustomer;
    }

    public async Task<CorporateCustomer> DeleteAsync(CorporateCustomer corporateCustomer, bool permanent = false)
    {
        CorporateCustomer deletedCorporateCustomer = await _corporateCustomerRepository.DeleteAsync(corporateCustomer);

        return deletedCorporateCustomer;
    }
}
