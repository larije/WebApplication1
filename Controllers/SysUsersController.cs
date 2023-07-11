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
    public class SysUsersController : ControllerBase
    {
        private readonly TestContext _context;

        public SysUsersController(TestContext context)
        {
            _context = context;
        }

        // GET: api/SysUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SysUser>>> GettSysUser()
        {
          if (_context.tSysUser == null)
          {
              return NotFound();
          }
            return await _context.tSysUser.ToListAsync();
        }

        // GET: api/SysUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SysUser>> GetSysUser(string id)
        {
          if (_context.tSysUser == null)
          {
              return NotFound();
          }
            var sysUser = await _context.tSysUser.FindAsync(id);

            if (sysUser == null)
            {
                return NotFound();
            }

            return sysUser;
        }

        // PUT: api/SysUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSysUser(string id, SysUser sysUser)
        {
            if (id != sysUser.userId)
            {
                return BadRequest();
            }

            _context.Entry(sysUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SysUserExists(id))
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

        // POST: api/SysUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SysUser>> PostSysUser(SysUser sysUser)
        {
          if (_context.tSysUser == null)
          {
              return Problem("Entity set 'TestContext.tSysUser'  is null.");
          }
            _context.tSysUser.Add(sysUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SysUserExists(sysUser.userId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSysUser", new { id = sysUser.userId }, sysUser);
        }

        // DELETE: api/SysUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSysUser(string id)
        {
            if (_context.tSysUser == null)
            {
                return NotFound();
            }
            var sysUser = await _context.tSysUser.FindAsync(id);
            if (sysUser == null)
            {
                return NotFound();
            }

            _context.tSysUser.Remove(sysUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SysUserExists(string id)
        {
            return (_context.tSysUser?.Any(e => e.userId == id)).GetValueOrDefault();
        }
    }
}
