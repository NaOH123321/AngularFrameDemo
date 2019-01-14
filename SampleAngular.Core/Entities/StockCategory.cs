using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAngular.Core.Entities
{
    public class StockCategory : Entity
    {
        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
