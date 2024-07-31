using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;

namespace shop_api.Controller
{
    [Route("api/check")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ValidationController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("{productCode}")]
        public async Task<IActionResult> CheckStockById(string productCode)
        {
            var allStocks = await _context.Stocks.Include(s => s.Product).ToListAsync();
            var stock = allStocks.Find(i => i.Product.ProductCode == productCode);
            if (stock.Amount <= 0) {
                return BadRequest("This Product is out of stock");
            }

            return Ok(stock);
        }
    }
}