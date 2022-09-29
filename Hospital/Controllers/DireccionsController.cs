using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital;
using Hospital.Data;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionsController : ControllerBase
    {
        private readonly DataContext _context;

        public DireccionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Direccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDireccion()
        {
            return await _context.Direccion.ToListAsync();
        }

        // GET: api/Direccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direccion>> GetDireccion(string id)
        {
            var direccion = await _context.Direccion.FindAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }

            return direccion;
        }

        // PUT: api/Direccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDireccion(string id, Direccion direccion)
        {
            if (id != direccion.direccion)
            {
                return BadRequest();
            }

            _context.Entry(direccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionExists(id))
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

        // POST: api/Direccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Direccion>> PostDireccion(Direccion direccion)
        {
            _context.Direccion.Add(direccion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DireccionExists(direccion.direccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDireccion", new { id = direccion.direccion }, direccion);
        }

        // DELETE: api/Direccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(string id)
        {
            var direccion = await _context.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }

            _context.Direccion.Remove(direccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DireccionExists(string id)
        {
            return _context.Direccion.Any(e => e.direccion == id);
        }
    }
}
