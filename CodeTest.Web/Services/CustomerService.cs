using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;

namespace CodeTest.Web.Services;

public class CustomerService(ApiService apiService)
{
    private readonly ApiService _apiService = apiService;

    public async Task<IEnumerable<CustomerResponse>> GetCustomers()
    {
        var result = await _apiService.HttpRequest<IEnumerable<CustomerResponse>>("Customer", HttpMethod.Get);

        return result;
    }

    public async Task AddCustomer(CustomerRequest request)
    {
        _ = await _apiService.HttpRequest<string>("Customer", HttpMethod.Post, content: request);
    }

    public async Task DeleteCustomer(int number)
    {
        _ = await _apiService.HttpRequest<string>($"Customer/by-number/{number}", HttpMethod.Delete);
    }

}
