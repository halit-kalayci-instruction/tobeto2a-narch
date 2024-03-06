using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.IndividualCustomers;

public interface IIndividualCustomerService
{
    Task<IndividualCustomer?> GetAsync(
        Expression<Func<IndividualCustomer, bool>> predicate,
        Func<IQueryable<IndividualCustomer>, IIncludableQueryable<IndividualCustomer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<IndividualCustomer>?> GetListAsync(
        Expression<Func<IndividualCustomer, bool>>? predicate = null,
        Func<IQueryable<IndividualCustomer>, IOrderedQueryable<IndividualCustomer>>? orderBy = null,
        Func<IQueryable<IndividualCustomer>, IIncludableQueryable<IndividualCustomer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IndividualCustomer> AddAsync(IndividualCustomer individualCustomer);
    Task<IndividualCustomer> UpdateAsync(IndividualCustomer individualCustomer);
    Task<IndividualCustomer> DeleteAsync(IndividualCustomer individualCustomer, bool permanent = false);
}
