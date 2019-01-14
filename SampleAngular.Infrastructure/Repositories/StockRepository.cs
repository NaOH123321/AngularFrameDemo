using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SampleAngular.Core.Entities;
using SampleAngular.Core.Interfaces;

namespace SampleAngular.Infrastructure.Repositories
{
    public class StockRepository : IRepository<Stock, StockParameters>
    {
        public Task<PaginatedList<Stock>> GetAllAsync(StockParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Stock t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Stock t)
        {
            throw new NotImplementedException();
        }

        public void Update(Stock t)
        {
            throw new NotImplementedException();
        }
    }
}
