using System;
using System.Collections.Generic;
using System.Text;
using SampleAngular.Core.Entities;
using SampleAngular.Infrastructure.Services;

namespace SampleAngular.Infrastructure.Resources.Stocks
{
    public class StockPropertyMapping: PropertyMapping<StockResource, Stock>
    {
        public StockPropertyMapping() : base(
            new Dictionary<string, List<MappedProperty>>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(StockResource.Name)] = new List<MappedProperty>()
                {
                    new MappedProperty() {Name = nameof(Stock.Name)}
                },
                [nameof(StockResource.Price)] = new List<MappedProperty>()
                {
                    new MappedProperty() {Name = nameof(Stock.Price)}
                },
                [nameof(StockResource.Rating)] = new List<MappedProperty>()
                {
                    new MappedProperty() {Name = nameof(Stock.Rating)}
                },
                [nameof(StockResource.Desc)] = new List<MappedProperty>()
                {
                    new MappedProperty() {Name = nameof(Stock.Desc)}
                }
            }
        )
        {
        }
    }
}



