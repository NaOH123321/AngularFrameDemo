using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Core.Entities;
using SampleAngular.Infrastructure.Resources.Stocks;
using SampleAngular.Infrastructure.Services;

namespace SampleAngular.App.Controllers
{
    public class StockController : BasicController<StockResource, Stock>
    {
        public StockController(IUrlHelper urlHelper,
            IPropertyMappingContainer propertyMappingContainer,
            ITypeHelperService typeHelperService)
            : base(urlHelper, propertyMappingContainer, typeHelperService)
        {

        }
    }
}
