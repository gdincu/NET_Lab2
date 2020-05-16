using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2.Persistence.Contexts;
using TaskManager.Domain.Models;

namespace Lab2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskManagerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskManager
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sarcina>>> GetSarcini(DateTimeOffset? from = null, DateTimeOffset? to = null)
        {
            //Filters results by deadline
            IQueryable<Sarcina> result = _context.Sarcini;
            if (from != null && to != null)
                result = result.Where(f => from <= f.Deadline && f.Deadline <= to);
            else if (from != null)
                result = result.Where(f => from <= f.Deadline);
            else if (to != null)
                result = result.Where(f => to <= f.Deadline);

            return await result.ToListAsync();
        }

        // GET: api/TaskManager/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sarcina>> GetSarcina(int id)
        {
            var sarcina = await _context.Sarcini.FindAsync(id);

            if (sarcina == null)
            {
                return NotFound();
            }         

            return sarcina;
        }

        // PUT: api/TaskManager/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSarcina(int id, Sarcina sarcina)
        {
            if (id != sarcina.Id)
            {
                return BadRequest();
            }

            //Ex.1 - Task 3
            if (sarcina.Stare.Equals(Stare.Closed))
            {
                sarcina.ClosedAt = DateTime.Now;
            }
            else
            {
                sarcina.ClosedAt = default;
            }

            _context.Entry(sarcina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SarcinaExists(id))
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

        // POST: api/TaskManager
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sarcina>> PostSarcina(Sarcina sarcina)
        {
            _context.Sarcini.Add(sarcina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSarcina", new { id = sarcina.Id }, sarcina);
        }

        // DELETE: api/TaskManager/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sarcina>> DeleteSarcina(int id)
        {
            var sarcina = await _context.Sarcini.FindAsync(id);
            if (sarcina == null)
            {
                return NotFound();
            }

            _context.Sarcini.Remove(sarcina);
            await _context.SaveChangesAsync();

            return sarcina;
        }

        private bool SarcinaExists(int id)
        {
            return _context.Sarcini.Any(e => e.Id == id);
        }
    }
}
