using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;
using CodeTest.Web.Configurations;

namespace CodeTest.Web.Services;

public class ApiService(
    IHttpClientFactory httpClientFactory,
    ApiConfig apiConfig)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ApiConfig _apiConfig = apiConfig;

    public async Task<T> HttpRequest<T>(string requestUri, HttpMethod method, object content = null, TimeSpan timeout = default)
    {
        var response = await HandleHttpRequest(requestUri, method, content, timeout);
        T result = await response.Content.ReadAsAsync<T>(); 
        return result;
    }

    private async Task<HttpResponseMessage> HandleHttpRequest(string requestUri, HttpMethod method, object content, TimeSpan timeout = default)
    {
        using var request = new HttpRequestMessage(method, requestUri);

        if (!string.IsNullOrEmpty(_apiConfig.ApiKey))
        {
            request.Headers.Add(_apiConfig.ApiKey, _apiConfig.ApiKeyValue);
        }

        using var client = _httpClientFactory.CreateClient(_apiConfig.Name);

        if (timeout != default)
        {
            client.Timeout = timeout;
        }

        if (content is not null)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        }

        /* Found where orders get stuck, 
         * when getting orders it does not manage to get past the client.SendAsync
         * 
         * It does not matter what I request, 
         * but if its requested from Orders.razor.cs it does not work
         * So by that there is a problem wih Orders.razor.cs 
         * but I cant manage to figure out what
         */
        var response = await client.SendAsync(request);

        //throw new Exception(message: request.ToString());


        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception(errorMessage);
        }
        return response;
    }
}
