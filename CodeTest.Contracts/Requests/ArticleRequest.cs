using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Contracts.Requests;
public class ArticleRequest
{
    public int ArticleId { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}
