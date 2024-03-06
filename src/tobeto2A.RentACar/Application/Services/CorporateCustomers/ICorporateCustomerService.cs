using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CorporateCustomers;

public interface ICorporateCustomerService
{
    Task<CorporateCustomer?> GetAsync(
        Expression<Func<CorporateCustomer, bool>> predicate,
        Func<IQueryable<CorporateCustomer>, IIncludableQueryable<CorporateCustomer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CorporateCustomer>?> GetListAsync(
        Expression<Func<CorporateCustomer, bool>>? predicate = null,
        Func<IQueryable<CorporateCustomer>, IOrderedQueryable<CorporateCustomer>>? orderBy = null,
        Func<IQueryable<CorporateCustomer>, IIncludableQueryable<CorporateCustomer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CorporateCustomer> AddAsync(CorporateCustomer corporateCustomer);
    Task<CorporateCustomer> UpdateAsync(CorporateCustomer corporateCustomer);
    Task<CorporateCustomer> DeleteAsync(CorporateCustomer corporateCustomer, bool permanent = false);
}
