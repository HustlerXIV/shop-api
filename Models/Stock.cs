using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
    }
}

