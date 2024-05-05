using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Web.FormModels;
using CodeTest.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CodeTest.Web.Components.Pages;

public partial class Articles
{
    [Inject]
    public ArticleService ArticleService { get; set; }

    private string _errorMessage = "";
    private bool _hasLoaded = false;
    private AddArticleForm _form;
    private IEnumerable<ArticleResponse> _articles;

    protected override async Task OnInitializedAsync()
    {
        _form = new();

        try
        {
            _articles = await ArticleService.GetArticles();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }

        _hasLoaded = true;
    }

    private void OnValidSubmit(EditContext context)
    {
        _hasLoaded = false;
        Task.Run(AddArticle);
        StateHasChanged();
    }

    private async Task AddArticle()
    {
        var newArticle = new ArticleRequest
        {
            ArticleId = _form.ArticleId,
            Description = _form.Description,
            Price = _form.Price,
        };

        try
        {
            await ArticleService.AddArticle(newArticle);
            _articles = await ArticleService.GetArticles();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }

        _hasLoaded = true;
        InvokeAsync(StateHasChanged);
    }

    private async Task DeleteCustomerById(int id)
    {
        _hasLoaded = false;
        InvokeAsync(StateHasChanged);

        try
        {
            await ArticleService.DeleteArticle(id);
            _articles = await ArticleService.GetArticles();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }

        _hasLoaded = true;
        InvokeAsync(StateHasChanged);
    }

}
