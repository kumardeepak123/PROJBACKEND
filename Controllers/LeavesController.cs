using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS.Models;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly LMS_Team5_Project10Context _context;

        public LeavesController(LMS_Team5_Project10Context context)
        {
            _context = context;
        }

        // GET: api/Leaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaves()
        {
            return await _context.Leaves.ToListAsync();
        }

        // GET: api/Leaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leave>> GetLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }

            return leave;
        }
        [HttpGet("bymanagerid/{id}")]

        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaves(int id)
        {
            var leave = await _context.Leaves.Where(i => i.Manid == id).ToListAsync();

            if (leave == null)
            {
                return NotFound();
            }

            return leave;
        }

        [HttpGet("byempid/{id}")]

        public async Task<ActionResult<IEnumerable<Leave>>> GetLeavesByEmpId(int id)
        {
            var leave = await _context.Leaves.Where(i => i.Empid == id).ToListAsync();

            if (leave == null)
            {
                return NotFound();
            }

            return leave;
        }


        // PUT: api/Leaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, Leave leave)
        {
            if (id != leave.Leaveid)
            {
                return BadRequest();
            }

            _context.Entry(leave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
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

        // POST: api/Leaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Leave>> PostLeave(Leave leave)
        {
            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeave", new { id = leave.Leaveid }, leave);
        }

        // DELETE: api/Leaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            _context.Leaves.Remove(leave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeaveExists(int id)
        {
            return _context.Leaves.Any(e => e.Leaveid == id);
        }
    }
}
