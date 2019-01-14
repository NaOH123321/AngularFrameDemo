using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAngular.Core.Entities
{
    public class Category : Entity
    {
        public Category()
        {
            StockCategories = new List<StockCategory>();
        }

        public string Name { get; set; }
        public DateTime CreateTime { get; set; }

        public List<StockCategory> StockCategories { get; set; }
    }
}
