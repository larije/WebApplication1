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
    public class projectTasksController : ControllerBase
    {
        private readonly TestContext _context;

        public projectTasksController(TestContext context)
        {
            _context = context;
        }

        // GET: api/projectTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<projectTask>>> GettprojectTask()
        {
          if (_context.tprojectTask == null)
          {
              return NotFound();
          }
            return await _context.tprojectTask.ToListAsync();
        }

        // GET: api/projectTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<projectTask>> GetprojectTask(string id)
        {
          if (_context.tprojectTask == null)
          {
              return NotFound();
          }
            var projectTask = await _context.tprojectTask.FindAsync(id);

            if (projectTask == null)
            {
                return NotFound();
            }

            return projectTask;
        }

        // PUT: api/projectTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutprojectTask(string id, projectTask projectTask)
        {
            if (id != projectTask.taskId)
            {
                return BadRequest();
            }

            _context.Entry(projectTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectTaskExists(id))
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

        // POST: api/projectTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<projectTask>> PostprojectTask(projectTask projectTask)
        {
          if (_context.tprojectTask == null)
          {
              return Problem("Entity set 'TestContext.tprojectTask'  is null.");
          }
            _context.tprojectTask.Add(projectTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (projectTaskExists(projectTask.taskId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetprojectTask", new { id = projectTask.taskId }, projectTask);
        }

        // DELETE: api/projectTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteprojectTask(string id)
        {
            if (_context.tprojectTask == null)
            {
                return NotFound();
            }
            var projectTask = await _context.tprojectTask.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            _context.tprojectTask.Remove(projectTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool projectTaskExists(string id)
        {
            return (_context.tprojectTask?.Any(e => e.taskId == id)).GetValueOrDefault();
        }
    }
}
