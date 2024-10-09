﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_Project.Models
{

    [Table("Stocks")]
    public class Stock
    {
        public int id {  get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set;} = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal purchase {  get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; } 
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
