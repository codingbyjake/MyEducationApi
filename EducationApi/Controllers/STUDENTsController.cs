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
    public class STUDENTsController : ControllerBase
    {
        private readonly EducationDbContext _context;

        public STUDENTsController(EducationDbContext context)
        {
            _context = context;
        }

        // GET: api/STUDENTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<STUDENT>>> GetSTUDENT()
        {
            return await _context.STUDENT.ToListAsync();
        }

        // GET: api/STUDENTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<STUDENT>> GetSTUDENT(int id)
        {
            var sTUDENT = await _context.STUDENT.FindAsync(id);

            if (sTUDENT == null)
            {
                return NotFound();
            }

            return sTUDENT;
        }

        // PUT: api/STUDENTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSTUDENT(int id, STUDENT sTUDENT)
        {
            if (id != sTUDENT.Id)
            {
                return BadRequest();
            }

            _context.Entry(sTUDENT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STUDENTExists(id))
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

        // POST: api/STUDENTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<STUDENT>> PostSTUDENT(STUDENT sTUDENT)
        {
            _context.STUDENT.Add(sTUDENT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSTUDENT", new { id = sTUDENT.Id }, sTUDENT);
        }

        // DELETE: api/STUDENTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSTUDENT(int id)
        {
            var sTUDENT = await _context.STUDENT.FindAsync(id);
            if (sTUDENT == null)
            {
                return NotFound();
            }

            _context.STUDENT.Remove(sTUDENT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool STUDENTExists(int id)
        {
            return _context.STUDENT.Any(e => e.Id == id);
        }
    }
}
