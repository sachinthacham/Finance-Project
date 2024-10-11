using Finance_Project.Contracts;
using Finance_Project.Helpers;
using Finance_Project.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance_Project.Repositories
{
    public class EFStockRepository:IStockRepository
    {
        private readonly EFDbContext _dbcontext;

        public EFStockRepository(EFDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<Stock>> getAllStock(QueryObject query)
        {
            var stocks = _dbcontext.Stocks.Include(c => c.Comments).AsQueryable();
            //filter by company name
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName == query.CompanyName);
            }
            
            //filter by symbol
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol == query.Symbol);
            }


            //sorting
            if (!string.IsNullOrWhiteSpace(query.sortBy))
            {
                if (query.sortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.Isdescending? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            //pagination
            var skipNumber = (query.pageNumber - 1) * query.pagesize;
            return await stocks.Skip(skipNumber).Take(query.pagesize).ToListAsync();
        }

        public async Task<Stock?> getStockById(int id)
        {
            return await _dbcontext.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Stock> CreateStock(Stock stock)
        {
            await _dbcontext.Stocks.AddAsync(stock);
            await _dbcontext.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> UpdateStock(int id)
        {
            return await _dbcontext.Stocks.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Stock?> DeleteStock(int id)
        {
            var stockToDelte = await _dbcontext.Stocks.FirstOrDefaultAsync(x => x.id == id);
            if(stockToDelte != null)
            {
                _dbcontext.Stocks.Remove(stockToDelte);
                await _dbcontext.SaveChangesAsync();
                return stockToDelte;
            }

            return null;
        }

        public async Task<bool> isStockExcisting(int id)
        {
            return await _dbcontext.Stocks.AnyAsync(x => x.id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
