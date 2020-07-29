using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Helper.Controllers;
using Helper.Data;

namespace Helper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClsadasdassesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClsadasdassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clsadasdasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clsadasdass>>> GetClsadasdass()
        {
            return await _context.Clsadasdass.ToListAsync();
        }

        // GET: api/Clsadasdasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clsadasdass>> GetClsadasdass(int id)
        {
            var clsadasdass = await _context.Clsadasdass.FindAsync(id);

            if (clsadasdass == null)
            {
                return NotFound();
            }

            return clsadasdass;
        }

        // PUT: api/Clsadasdasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClsadasdass(int id, Clsadasdass clsadasdass)
        {
            if (id != clsadasdass.MyProperty)
            {
                return BadRequest();
            }

            _context.Entry(clsadasdass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsadasdassExists(id))
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

        // POST: api/Clsadasdasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clsadasdass>> PostClsadasdass(Clsadasdass clsadasdass)
        {
            _context.Clsadasdass.Add(clsadasdass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClsadasdass", new { id = clsadasdass.MyProperty }, clsadasdass);
        }

        // DELETE: api/Clsadasdasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clsadasdass>> DeleteClsadasdass(int id)
        {
            var clsadasdass = await _context.Clsadasdass.FindAsync(id);
            if (clsadasdass == null)
            {
                return NotFound();
            }

            _context.Clsadasdass.Remove(clsadasdass);
            await _context.SaveChangesAsync();

            return clsadasdass;
        }

        private bool ClsadasdassExists(int id)
        {
            return _context.Clsadasdass.Any(e => e.MyProperty == id);
        }
    }
}
