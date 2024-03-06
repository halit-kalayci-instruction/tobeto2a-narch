using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Customers;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly CustomerBusinessRules _customerBusinessRules;

    public CustomerManager(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules)
    {
        _customerRepository = customerRepository;
        _customerBusinessRules = customerBusinessRules;
    }

    public async Task<Customer?> GetAsync(
        Expression<Func<Customer, bool>> predicate,
        Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Customer? customer = await _customerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customer;
    }

    public async Task<IPaginate<Customer>?> GetListAsync(
        Expression<Func<Customer, bool>>? predicate = null,
        Func<IQueryable<Customer>, IOrderedQueryable<Customer>>? orderBy = null,
        Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Customer> customerList = await _customerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerList;
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        Customer addedCustomer = await _customerRepository.AddAsync(customer);

        return addedCustomer;
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        Customer updatedCustomer = await _customerRepository.UpdateAsync(customer);

        return updatedCustomer;
    }

    public async Task<Customer> DeleteAsync(Customer customer, bool permanent = false)
    {
        Customer deletedCustomer = await _customerRepository.DeleteAsync(customer);

        return deletedCustomer;
    }
}
