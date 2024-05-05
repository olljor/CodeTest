using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Infrastructure.Repositories;
public static class CustomerRepository
{
    public static string GetCustomers { get; private set; } = "SELECT * FROM [Customer]";
    
    public static string DeleteCustomerByNumber { get; private set; } = """
    DELETE FROM [Customer] 
    WHERE [CustomerNumber] = @CustomerNumber
    """;

    public static string AddCustomer { get; private set; } = """
    INSERT INTO [Customer] 
    ([CustomerNumber], [CustomerName]) 
    VALUES (@CustomerNumber, @CustomerName)
    """;
}
