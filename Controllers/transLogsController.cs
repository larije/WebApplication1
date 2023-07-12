using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.data;
using WebApplication1.model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transLogsController : ControllerBase
    {
        private readonly TestContext _context;

        public transLogsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/transLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<transLog>>> GettTransLog()
        {
          if (_context.tTransLog == null)
          {
              return NotFound();
          }
            return await _context.tTransLog.ToListAsync();
        }

        // GET: api/transLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<transLog>> GettransLog(string id)
        {
          if (_context.tTransLog == null)
          {
              return NotFound();
          }
            var transLog = await _context.tTransLog.FindAsync(id);

            if (transLog == null)
            {
                return NotFound();
            }

            return transLog;
        }

        // PUT: api/transLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttransLog(string id, transLog transLog)
        {
            if (id != transLog.logId)
            {
                return BadRequest();
            }

            _context.Entry(transLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transLogExists(id))
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

        // POST: api/transLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<transLog>> PosttransLog(transLog transLog)
        {
          if (_context.tTransLog == null)
          {
              return Problem("Entity set 'TestContext.tTransLog'  is null.");
          }
            _context.tTransLog.Add(transLog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (transLogExists(transLog.logId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GettransLog", new { id = transLog.logId }, transLog);
        }

        // DELETE: api/transLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetransLog(string id)
        {
            if (_context.tTransLog == null)
            {
                return NotFound();
            }
            var transLog = await _context.tTransLog.FindAsync(id);
            if (transLog == null)
            {
                return NotFound();
            }

            _context.tTransLog.Remove(transLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool transLogExists(string id)
        {
            return (_context.tTransLog?.Any(e => e.logId == id)).GetValueOrDefault();
        }
    }
}
