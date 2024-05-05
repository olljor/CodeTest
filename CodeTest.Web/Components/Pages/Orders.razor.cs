using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Web.FormModels;
using CodeTest.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Data.Common;

namespace CodeTest.Web.Components.Pages;

public partial class Orders
{

    [Inject]
    public OrderService OrderService { get; set; }

    private string _errorMessage = "";
    private bool _hasLoaded = false;

    private AddOrderForm _addOrderForm;
    private SearchOrderForm _searchOrderForm;
    private SearchOrderRowForm searchOrderRow;

    private IEnumerable<OrderResponse> _orders;
    private IEnumerable<OrderRowResponse> _orderRows;

    private string _searchedObjective;

    protected override async void OnInitialized()
    {
        _addOrderForm = new AddOrderForm();
        _searchOrderForm = new SearchOrderForm();
        _searchedObjective = "";
        try
        {
            _orders = await OrderService.GetOrders();
            _orderRows = await OrderService.GetOrderRows();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }
        _hasLoaded = true;
        InvokeAsync(StateHasChanged);
    }
    private void OnValidAddOrder(EditContext context)
    {
        _hasLoaded = false;
        Task.Run(AddOrder);
        StateHasChanged();
    }

    private async Task AddOrder()
    {

        var newOrder = new OrderRequest
        {
            OrderId = GenerateId(),
            CustomerNumber = _addOrderForm.CustomerNumber
        };

        // I asume that one customer can put multiple orders 
        try
        {
            await OrderService.AddOrder(newOrder);
            _orders = await OrderService.GetOrders();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }

        _hasLoaded = true;
        InvokeAsync(StateHasChanged);
    }

    private int GenerateId()
    {
        // Preferably we use a unique id derived from something else,
        // but this is a temporary solution 
        IEnumerable<OrderResponse> idSorted = _orders.OrderBy(order => order.OrderId);
        int idCheck = 1;
        foreach (var order in _orders)
        {
            if (idCheck != order.OrderId)
            {
                return idCheck;
            }
            idCheck++;
        }
        return idCheck;
    }

    private async Task DeleteOrderById(int id)
    {
        _hasLoaded = false;
        InvokeAsync(StateHasChanged);

        try
        {
            await OrderService.DeleteOrder(id);
            _orders = await OrderService.GetOrders();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
        }

        _hasLoaded = true;
        InvokeAsync(StateHasChanged);
    }

    private async Task OnValidSearchOrder()
    {
        // I am assuming that there order id is unique 

        OrderResponse? result;
        try
        {
            // Good way to do it 
            result = await OrderService.GetOrderById(_searchOrderForm.OrderId);

            // Bad way to do it
            //_orders = await OrderService.GetOrders();
            //result = _orders.FirstOrDefault(order => order.OrderId == _searchOrderForm.OrderId);
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
            throw;
        }

        if (result.OrderId == -1)
            _searchedObjective = $"No result could be found for {_searchOrderForm.OrderId}";
        else
            _searchedObjective = $"Your for order: {result.OrderId} which has customer number: {result.CustomerNumber}";
    }
    //TODO: impliment code to display orders
}
