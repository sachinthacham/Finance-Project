using Finance_Project.DTOs.stock;
using Finance_Project.Models;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Finance_Project.Mappers
{
    public static class StockMappers
    {
       public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                id = stockModel.id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                purchase = stockModel.purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),

            };
        } 


        public static Stock ToStockFromCreateDto(this CreateStockRequest stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                purchase = stockDto.purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}
