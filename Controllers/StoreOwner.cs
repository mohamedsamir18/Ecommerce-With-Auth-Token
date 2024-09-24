using EcommerceAuthToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAuthToken.Controllers
{
    [Authorize(Roles ="StoreOwner")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreOwner : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StoreOwner(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProduct([FromBody] ProductModel model)
        {
            _context.products.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(model), new { id = model.ID }, model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateProduct(int id,ProductModel updatedproduct)
        {
            if (id != updatedproduct.ID)
            {
                return BadRequest("the ID u entered doesn't match");
            }
            var product = await _context.products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            product.ProductName = updatedproduct.ProductName;
            product.ProductDescription = updatedproduct.ProductDescription;
            await _context.SaveChangesAsync();
            return Ok(updatedproduct);
        }
        [HttpPut("{id2}")]
        public async Task<IActionResult> UpdateOrder(int id2, OrederModel orderstatus)
        {
            if (id2 != orderstatus.Id)
            {
                return BadRequest("the ID u entered doesn't match");
            }
            var order = await _context.oreders.FindAsync(id2);
            if (order == null)
            {
                return NotFound();
            }
            order.OrderStatus = orderstatus.OrderStatus;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
