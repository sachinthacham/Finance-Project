using Finance_Project.DTOs.comment;
using Finance_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_Project.DTOs.stock
{
    public class StockDto
    {
        public int id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        
        public decimal purchase { get; set; }
        
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; }



    }
}
