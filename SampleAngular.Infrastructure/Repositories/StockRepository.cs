using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Core.Entities;
using SampleAngular.Core.Interfaces;
using SampleAngular.Infrastructure.Database;
using SampleAngular.Infrastructure.Extensions;
using SampleAngular.Infrastructure.Resources.Stocks;
using SampleAngular.Infrastructure.Services;

namespace SampleAngular.Infrastructure.Repositories
{
    public class StockRepository : IRepository<Stock, StockParameters>
    {
        private readonly MyContext _myContext;
        private readonly IPropertyMappingContainer _propertyMappingContainer;

        public StockRepository(MyContext myContext, IPropertyMappingContainer propertyMappingContainer)
        {
            _myContext = myContext;
            _propertyMappingContainer = propertyMappingContainer;
        }

        public async Task<PaginatedList<Stock>> GetAllAsync(StockParameters parameters)
        {
            var query = _myContext.Stocks.Include(x=>x.StockCategories)
                .ThenInclude(x=>x.Category)
                .AsQueryable();

            //if (!string.IsNullOrEmpty(parameters.Title))
            //{
            //    var title = parameters.Title.ToLowerInvariant();
            //    query = query.Where(x => x.Title.ToLowerInvariant().Contains(title));
            //}

            query = query.ApplySort(parameters.OrderBy,
                _propertyMappingContainer.Resolve<StockResource, Stock>());

            var count = await _myContext.Stocks.CountAsync();
            var data = await query
                .Skip(parameters.PageIndex * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
            return new PaginatedList<Stock>(parameters.PageIndex, parameters.PageSize, count, data);

        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _myContext.Stocks.Where(x=>x.Id==id).Include(x => x.StockCategories)
                .ThenInclude(x => x.Category).FirstAsync();
        }

        public void Add(Stock t)
        {
            _myContext.Add(t);
        }

        public void Delete(Stock t)
        {
            _myContext.Stocks.Remove(t);
        }

        public void Update(Stock t)
        {
            t.StockCategories.ForEach(x =>
            {
                x.Category = _myContext.Categories.First(c => c.Name == x.Category.Name);
                x.Stock = t;
            });

            _myContext.Entry(t).State = EntityState.Modified;
        }
    }
}
