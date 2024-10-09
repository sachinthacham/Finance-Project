using Finance_Project.Helpers;
using Finance_Project.Models;
namespace Finance_Project.Contracts
{
    public interface IStockRepository
    {
        Task<List<Stock>> getAllStock(QueryObject query);
        Task<Stock?> getStockById(int id);
        Task<Stock> CreateStock(Stock stock);
        Task<Stock?> UpdateStock(int id);
        Task<Stock?> DeleteStock (int id); 
        Task<bool> isStockExcisting(int id);
        Task SaveChangesAsync();
    }
}
