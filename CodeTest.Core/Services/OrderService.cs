using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Infrastructure.Entities;
using CodeTest.Infrastructure.Repositories;
using Dapper;
using Microsoft.Extensions.Logging;


namespace CodeTest.Core.Services;
public class OrderService(IDbConnection connection)
{
    private readonly IDbConnection _connection = connection;

    public async Task<IEnumerable<OrderResponse>> GetOrders()
    {
        var result = await _connection.QueryAsync<Order>(OrderRepository.GetOrders);
        return result.Select(order => new OrderResponse
        {
            OrderId = order.OrderId,
            CustomerNumber = order.CustomerNumber,
        });
    }

    //TODO: make method that uses dapper to get the order with id
    public async Task<OrderResponse> GetOrderById(int id)
    {
        var result = await _connection.QuerySingleOrDefaultAsync<Order>(OrderRepository.GetOrderById, new { OrderId = id });
        if (result == null)
        {
            return new OrderResponse
            {
                OrderId = -1,
                CustomerNumber = 0,
            };
        }
        else
        {
            return new OrderResponse
            {
                OrderId = result.OrderId,
                CustomerNumber = result.CustomerNumber,
            };
        }
    }

    public async Task AddOrder(OrderRequest orderRequest)
    {
        await _connection.ExecuteAsync(OrderRepository.AddOrder,
           new
           {
               orderRequest.OrderId,
               orderRequest.CustomerNumber
           });
    }

    public async Task DeleteOrderById(int id)
    {
        await _connection.ExecuteAsync(OrderRepository.DeleteOrderById, new { OrderId = id });
    }

    public async Task<IEnumerable<OrderRowResponse>> GetOrderRows()
    {
        var result = await _connection.QueryAsync<OrderRow>(OrderRepository.GetOrderRow);
        return result.Select(orderRow => new OrderRowResponse
        {
            Id = orderRow.Id,
            ArticleId = orderRow.ArticleId,
            OrderId = orderRow.OrderId,
            Amount = orderRow.Amount,
        });
    }
}
