﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Contracts.Response;
public class OrderResponse
{
    public int OrderId { get; set; }

    public int? CustomerNumber { get; set; }
}
