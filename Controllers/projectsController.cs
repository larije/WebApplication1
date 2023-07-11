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
    public class projectsController : ControllerBase
    {
        private readonly TestContext _context;

        public projectsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<project>>> GettProject()
        {
          if (_context.tProject == null)
          {
              return NotFound();
          }
            return await _context.tProject.ToListAsync();
        }

        // GET: api/projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<project>> Getproject(string id)
        {
          if (_context.tProject == null)
          {
              return NotFound();
          }
            var project = await _context.tProject.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproject(string id, project project)
        {
            if (id != project.projId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectExists(id))
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

        // POST: api/projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<project>> Postproject(project project)
        {
          if (_context.tProject == null)
          {
              return Problem("Entity set 'TestContext.tProject'  is null.");
          }
            _context.tProject.Add(project);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (projectExists(project.projId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getproject", new { id = project.projId }, project);
        }

        // DELETE: api/projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproject(string id)
        {
            if (_context.tProject == null)
            {
                return NotFound();
            }
            var project = await _context.tProject.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.tProject.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool projectExists(string id)
        {
            return (_context.tProject?.Any(e => e.projId == id)).GetValueOrDefault();
        }
    }
}
