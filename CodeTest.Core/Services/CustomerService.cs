
using CodeTest.Infrastructure.Entities;
using Microsoft.Extensions.Logging;
using System.Data;
using Dapper;
using CodeTest.Infrastructure.Repositories;
using CodeTest.Contracts.Response;
using CodeTest.Contracts.Requests;

namespace CodeTest.Core.Services;
public class CustomerService(IDbConnection connection)
{
    private readonly IDbConnection _connection = connection;

    public async Task<IEnumerable<CustomerResponse>> GetCustomers()
    {
        var result = await _connection.QueryAsync<Customer>(CustomerRepository.GetCustomers);
        return result.Select(customer => new CustomerResponse
        {
            CustomerNumber = customer.CustomerNumber,
            CustomerName = customer.CustomerName,
        });
    }

    public async Task DeleteCustomerByNumber(int number)
    {
        await _connection.ExecuteAsync(CustomerRepository.DeleteCustomerByNumber, new { CustomerNumber = number });
    }

    public async Task AddCustomer(CustomerRequest customerRequest)
    {
         await _connection.ExecuteAsync(CustomerRepository.AddCustomer,
            new
            {
                customerRequest.CustomerNumber,
                customerRequest.CustomerName
            });
    }

}
