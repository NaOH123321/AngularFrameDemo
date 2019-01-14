using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAngular.Infrastructure.Resources.Stocks
{
    public class StockResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string Desc { get; set; }
    }
}
