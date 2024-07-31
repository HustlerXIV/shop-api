using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;

namespace shop_api.Controller
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allProducts = await _context.Products.ToListAsync();
            return Ok(allProducts);
        }
    }
}