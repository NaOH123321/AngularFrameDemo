using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAngular.Core.Entities
{
    public class Stock : Entity
    {
        public Stock()
        {
            StockCategories = new List<StockCategory>();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string Desc { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime CreateTime { get; set; }

        public List<StockCategory> StockCategories { get; set; }
    }
}
