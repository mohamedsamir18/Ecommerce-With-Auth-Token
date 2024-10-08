﻿using EcommerceAuthToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAuthToken.Controllers
{
    [Authorize(Roles ="Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Oreder>> CreateOrder([FromBody] Oreder model)
        {
            await _context.oreders.AddAsync(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(model), new { id = model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.oreders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            _context.oreders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
