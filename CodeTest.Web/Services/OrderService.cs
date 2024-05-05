using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;

namespace CodeTest.Web.Services;

public class OrderService(ApiService apiService)
{
    private readonly ApiService _apiService = apiService;

    public async Task<IEnumerable<OrderResponse>> GetOrders()
    {
        var result = await _apiService.HttpRequest<IEnumerable<OrderResponse>>("Order", HttpMethod.Get);
        return result;
    }
    public async Task<OrderResponse> GetOrderById(int id)
    {
        var result = await _apiService.HttpRequest<OrderResponse>($"Order/by-id/{id}", HttpMethod.Get);
        return result;
    }
    public async Task AddOrder(OrderRequest request)
    {
        _ = await _apiService.HttpRequest<string>("Order", HttpMethod.Post, content: request);
    }
    public async Task DeleteOrder(int id)
    {
        _ = await _apiService.HttpRequest<string>($"Order/by-id/{id}", HttpMethod.Delete);
    }
    public async Task<IEnumerable<OrderRowResponse>> GetOrderRows()
    {
        var result = await _apiService.HttpRequest<IEnumerable<OrderRowResponse>>($"Order/rows", HttpMethod.Get);
        return result;
    }
}
