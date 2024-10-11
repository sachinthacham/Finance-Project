using System.ComponentModel.DataAnnotations;

namespace Finance_Project.DTOs.stock
{
    public class CreateStockRequest
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000000)]
        public decimal purchase { get; set; }
        
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(5, 10000000)]
        public long MarketCap { get; set; }

    }
}
