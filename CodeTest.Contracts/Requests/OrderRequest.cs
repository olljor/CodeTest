using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Contracts.Requests;
public class OrderRequest
{
    public int OrderId{ get; set; }

    public int CustomerNumber { get; set; }

}
