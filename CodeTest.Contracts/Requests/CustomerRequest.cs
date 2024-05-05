using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Contracts.Requests;
public class CustomerRequest
{
    public int CustomerNumber { get; set; }

    public string CustomerName { get; set; }
}
