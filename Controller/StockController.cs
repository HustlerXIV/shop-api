using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Models;

namespace shop_api.Controller
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStock()
        {
            var allStocks = await _context.Stocks
                .Include(s => s.Product)
                .ToListAsync();
            return Ok(allStocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] Stock stock)
        {
            if (stock == null)
            {
                return BadRequest("Stock is null.");
            }

            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateStock([FromBody] List<Stock?> stocks)
        {
            foreach(var stock in stocks)
            {
                var isOutOfStockText = " is out of stock.";
                var existingStock = await _context.Stocks.FindAsync(stock.Product.Id);
                var calculatedAmount = existingStock.Amount - stock.Amount;

                if (calculatedAmount > 0) {
                    existingStock.Amount = existingStock.Amount - stock.Amount;
                } else {
                    existingStock.Amount = 0;
                    return BadRequest(stock.Product.ProductName + isOutOfStockText);
                }

                _context.Stocks.Update(existingStock);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}