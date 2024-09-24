﻿using EcommerceAuthToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAuthToken.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdmin : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SuperAdmin(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<StoreModel>> PostStore([FromBody] StoreModel model)
        {
            _context.stores.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(model), new { id = model.Id }, model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteStore(int id)
        {
            var store = await _context.stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            _context.stores.Remove(store);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
