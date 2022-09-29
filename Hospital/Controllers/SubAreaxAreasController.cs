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
    public class SubAreaxAreasController : ControllerBase
    {
        private readonly DataContext _context;

        public SubAreaxAreasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SubAreaxAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubAreaxArea>>> GetSubAreaxArea()
        {
            return await _context.SubAreaxArea.ToListAsync();
        }

        // GET: api/SubAreaxAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubAreaxArea>> GetSubAreaxArea(int id)
        {
            var subAreaxArea = await _context.SubAreaxArea.FindAsync(id);

            if (subAreaxArea == null)
            {
                return NotFound();
            }

            return subAreaxArea;
        }

        // PUT: api/SubAreaxAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubAreaxArea(int id, SubAreaxArea subAreaxArea)
        {
            if (id != subAreaxArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(subAreaxArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubAreaxAreaExists(id))
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

        // POST: api/SubAreaxAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubAreaxArea>> PostSubAreaxArea(SubAreaxArea subAreaxArea)
        {
            _context.SubAreaxArea.Add(subAreaxArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubAreaxArea", new { id = subAreaxArea.Id }, subAreaxArea);
        }

        // DELETE: api/SubAreaxAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubAreaxArea(int id)
        {
            var subAreaxArea = await _context.SubAreaxArea.FindAsync(id);
            if (subAreaxArea == null)
            {
                return NotFound();
            }

            _context.SubAreaxArea.Remove(subAreaxArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubAreaxAreaExists(int id)
        {
            return _context.SubAreaxArea.Any(e => e.Id == id);
        }
    }
}
