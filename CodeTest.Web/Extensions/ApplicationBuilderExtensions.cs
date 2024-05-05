using CodeTest.Web.Configurations;
using CodeTest.Web.Services;

namespace CodeTest.Web.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<ApiService>();
        services.AddTransient<ArticleService>();
        services.AddTransient<CustomerService>();
        services.AddTransient<OrderService>();
        services.AddTransient<SetupService>();

        return services;
    }

    public static WebApplicationBuilder AddHttpClients(this WebApplicationBuilder builder)
    {
        ApiConfig apiConfig = new();
        builder.Configuration.GetSection("APIClients:Clients:CodeTest").Bind(apiConfig);
        builder.Services.AddSingleton(apiConfig);

        builder.Services.AddHttpClient(apiConfig.Name, c =>
        {
            c.BaseAddress = new Uri(builder.Configuration[$"API:Address:{apiConfig.Name}"]!);
        });

        return builder;
    }

}
