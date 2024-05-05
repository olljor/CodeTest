using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Infrastructure.Repositories;
public static class OrderRepository
{
    public static string GetOrders { get; private set; } = "SELECT * FROM [Order]";
    
    public static string GetOrderById { get; private set; } = """
        SELECT * FROM [Order]
        WHERE [OrderId] = @OrderId
    """;

    public static string AddOrder { get; private set; } = """
    INSERT INTO [Order] 
    ([OrderId], [CustomerNumber]) 
    VALUES (@OrderId, @CustomerNumber)
    """;
    
    public static string DeleteOrderById { get; private set; } = """
    DELETE FROM [Order] 
    WHERE [OrderId] = @OrderId
    """;

    public static string GetOrderRow { get; private set; } = """
        SELECT * FROM [OrderRow]
    """;

    //TODO: add dapper sql querys

}
