namespace CodeTest.Web.Services;

public class SetupService(ApiService apiService)
{
    public ApiService _apiService = apiService;

    public async Task RunDatabaseSetupScript()
    {
        await _apiService.HttpRequest<string>("setup", HttpMethod.Post);
    }
}
