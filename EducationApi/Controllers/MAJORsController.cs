using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationApi.Models;

namespace EducationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MAJORsController : ControllerBase
    {
        private readonly EducationDbContext _context;

        public MAJORsController(EducationDbContext context)
        {
            _context = context;
        }

        // GET: api/MAJORs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MAJOR>>> GetMAJOR()
        {
            return await _context.MAJOR.ToListAsync();
        }

        // GET: api/MAJORs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MAJOR>> GetMAJOR(int id)
        {
            var mAJOR = await _context.MAJOR.FindAsync(id);

            if (mAJOR == null)
            {
                return NotFound();
            }

            return mAJOR;
        }

        // PUT: api/MAJORs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMAJOR(int id, MAJOR mAJOR)
        {
            if (id != mAJOR.Id)
            {
                return BadRequest();
            }

            _context.Entry(mAJOR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MAJORExists(id))
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

        // POST: api/MAJORs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MAJOR>> PostMAJOR(MAJOR mAJOR)
        {
            _context.MAJOR.Add(mAJOR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMAJOR", new { id = mAJOR.Id }, mAJOR);
        }

        // DELETE: api/MAJORs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMAJOR(int id)
        {
            var mAJOR = await _context.MAJOR.FindAsync(id);
            if (mAJOR == null)
            {
                return NotFound();
            }

            _context.MAJOR.Remove(mAJOR);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MAJORExists(int id)
        {
            return _context.MAJOR.Any(e => e.Id == id);
        }
    }
}
