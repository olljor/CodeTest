using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Web.FormModels;
using CodeTest.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Data.Common;

namespace CodeTest.Web.Components.Pages;

public partial class Customer
{
    [Inject]
    public CustomerService CustomerService { get; set; }
    private string _errorMessage = "";
    private bool _hasLoaded = false;
    private AddCustomerForm _form;
    private IEnumerable<CustomerResponse> _customers;

    protected override async Task OnInitializedAsync()
    {
        _form = new();
        try
        {
            _customers = await CustomerService.GetCustomers();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }

        _hasLoaded = true;
    }

    private void OnValidAddCustomer(EditContext context)
    {
        _hasLoaded = false;
        Task.Run(AddCustomer);
        StateHasChanged();
    }

    private async Task AddCustomer()
    {
        var newCustomer = new CustomerRequest
        {
            CustomerName = _form.CustomerName,
            CustomerNumber = _form.CustomerNumber
        };

        try
        {
            await CustomerService.AddCustomer(newCustomer);
            _customers = await CustomerService.GetCustomers();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }
        _hasLoaded = true;
        InvokeAsync(StateHasChanged);
    }

    private async Task DeleteCustomerByNumber(int number)
    {
        _hasLoaded = false;
        InvokeAsync(StateHasChanged);

        try
        {
            await CustomerService.DeleteCustomer(number);
            _customers = await CustomerService.GetCustomers();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }

        _hasLoaded = true;
        InvokeAsync(StateHasChanged);
    }

}