using Finance_Project.Contracts;
using Finance_Project.DTOs.stock;
using Finance_Project.Helpers;
using Finance_Project.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Project.Controllers
{
    [Route("api/stock")]
    [ApiController]
    
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> getAllStocks([FromQuery]QueryObject query)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var stocks = await _stockRepository.getAllStock(query);
                if (stocks == null)
                {
                    return NotFound();
                }

                var stockDto = stocks.Select(s => s.ToStockDto());
                return Ok(stockDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{id:int}")]

        public async Task<IActionResult> getStockById ([FromRoute] int id)
        {
            try
            {
                var stock = await _stockRepository.getStockById(id);
                if(stock == null)
                {
                    return NotFound();  
                }

                return Ok(stock.ToStockDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("add")]

        public async  Task<IActionResult> addStock([FromBody] CreateStockRequest stockDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var stockModel  = await _stockRepository.CreateStock(stockDto.ToStockFromCreateDto());
                await _stockRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(getStockById), new { id = stockModel.id }, stockModel.ToStockDto());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("update/{id:int}")]

        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequest stockdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var excistingStock = await _stockRepository.getStockById(id);
                if(excistingStock == null)
                {
                    return NotFound();
                }

                excistingStock.Symbol = stockdto.Symbol;
                excistingStock.purchase = stockdto.purchase;
                excistingStock.CompanyName = stockdto.CompanyName;
                excistingStock.LastDiv=stockdto.LastDiv;
                excistingStock.Industry = stockdto.Industry;
                excistingStock.MarketCap = stockdto.MarketCap;

                return Ok(excistingStock.ToStockDto());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


           
        }

        [HttpDelete]
        [Route("delete/{id:int}")]

        public async Task<IActionResult> deleteStock([FromRoute] int id)
        {
            var ItemTobeDeleted = await _stockRepository.DeleteStock(id);
            if(ItemTobeDeleted == null)
            {
                return NotFound();
            }
            return Ok(ItemTobeDeleted.ToStockDto());
        }
    }
}
