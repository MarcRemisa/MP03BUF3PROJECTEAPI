using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AstronautasApi.Models;

namespace atronautas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautasController : ControllerBase
    {
        private readonly TodoContext _context;

        public AstronautasController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Astronautas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AstronautasItem>>> GetAstronautasItem()
        {
            return await _context.AstronautasItem.ToListAsync();
        }

        // GET: api/Astronautas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AstronautasItem>> GetAstronautasItem(long id)
        {
            var astronautasItem = await _context.AstronautasItem.FindAsync(id);

            if (astronautasItem == null)
            {
                return NotFound();
            }

            return astronautasItem;
}

        // PUT: api/Astronautas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAstronautasItem(long id, AstronautasItem astronautasItem)
        {
            if (id != astronautasItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(astronautasItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AstronautasItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Astronautas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AstronautasItem>> PostAstronautasItem(AstronautasItem astronautasItem)
        {
            _context.AstronautasItem.Add(astronautasItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("PostTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(PostAstronautasItem), new { id = astronautasItem.Id }, astronautasItem);
        }

        // DELETE: api/Astronautas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAstronautasItem(long id)
        {
            var astronautasItem = await _context.AstronautasItem.FindAsync(id);
            if (astronautasItem == null)
            {
                return NotFound();
            }

            _context.AstronautasItem.Remove(astronautasItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AstronautasItemExists(long id)
        {
            return _context.AstronautasItem.Any(e => e.Id == id);
        }
    }
}
