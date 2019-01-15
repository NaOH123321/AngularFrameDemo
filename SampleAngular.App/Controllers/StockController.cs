using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Core.Entities;
using SampleAngular.Core.Interfaces;
using SampleAngular.Infrastructure.Database;
using SampleAngular.Infrastructure.Extensions;
using SampleAngular.Infrastructure.Resources.Stocks;
using SampleAngular.Infrastructure.Services;

namespace SampleAngular.App.Controllers
{
    [Route("api/stock")]
    public class StockController : BasicController<StockResource, Stock>
    {
        private readonly MyContext _myContext;
        private readonly IRepository<Stock, StockParameters> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StockController(MyContext myContext,
            IRepository<Stock, StockParameters> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            IUrlHelper urlHelper,
            IPropertyMappingContainer propertyMappingContainer,
            ITypeHelperService typeHelperService)
            : base(urlHelper, propertyMappingContainer, typeHelperService)
        {
            _myContext = myContext;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetStocks")]
        public async Task<IActionResult> Get(StockParameters parameters)
        {
            ValidateMapping(parameters.OrderBy);
            ValidateFields(parameters.Fields);
            if (Results.Count != 0) return Results.First();

            var list = await _repository.GetAllAsync(parameters);

            var resources = _mapper.Map<IEnumerable<Stock>, IEnumerable<StockResource>>(list);

            var shapedResources = resources.ToDynamicIEnumerable(parameters.Fields);

            CreateHeader(parameters, list, "GetStocks");

            return Ok(shapedResources);
        }

        [HttpGet("{id}", Name = "GetStock")]
        public async Task<IActionResult> Get(int id, string fields = null)
        {
            ValidateFields(fields);
            if (Results.Count != 0) return Results.First();

            var stock = await _repository.GetByIdAsync(id);

            ValidateNotFound(stock);
            if (Results.Count != 0) return Results.First();

            var resource = _mapper.Map<Stock, StockResource>(stock);

            var shapedResource = resource.ToDynamic(fields);

            return Ok(shapedResource);
        }

        [HttpPut("{id}", Name = "UpdateStock")]
        public async Task<IActionResult> Put(int id, [FromBody] StockResource stockResource)
        {
            ValidateNotNull(stockResource);
            ValidateParameters();
            if (Results.Count != 0) return Results.First();

            var stock = await _repository.GetByIdAsync(id);

            ValidateNotFound(stock);
            if (Results.Count != 0) return Results.First();

            stock.LastModified = DateTime.Now;
            _mapper.Map(stockResource, stock);

            var list = new List<StockCategory>();
            foreach (var categoryName in stockResource.Categories)
            {
                var category = _myContext.Categories.First(x => x.Name == categoryName);

                list.Add(new StockCategory()
                {
                    Category = category,
                    Stock = stock
                });
            }
            stock.StockCategories = list;

            _repository.Update(stock);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating stock {id} failed when saving.");
            }

            return Ok(_mapper.Map<StockResource>(stock));
        }
    }
}
