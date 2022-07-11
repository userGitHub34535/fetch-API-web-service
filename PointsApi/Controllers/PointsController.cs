using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointsApi.Models;

namespace PointsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly PointsContext _context;

        public PointsController(PointsContext context)
        {
            _context = context;
        }

        // GET: api/Points
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Points>>> GetPoints()
        {
          if (_context.Points == null)
          {
              return NotFound();
          }
            return await _context.Points.ToListAsync();
        }

        // GET: api/Points/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Points>> GetPoints(long id)
        {
          if (_context.Points == null)
          {
              return NotFound();
          }
            var points = await _context.Points.FindAsync(id);

            if (points == null)
            {
                return NotFound();
            }

            return points;
        }

        //// PUT: api/Points/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPoints(long id, Points points)
        //{
        //    if (id != points.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(points).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PointsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Points
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Points>> PostPoints(Points points)
        {
          if (_context.Points == null)
          {
              return Problem("Entity set 'PointsContext.PointsRecords'  is null.");
          }
            _context.Points.Add(points);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPoints), new { id = points.Id }, points);
            //return CreatedAtAction("GetPoints", new { id = points.Id }, points);
        }

        // DELETE: api/Points/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoints(long id)
        {
            if (_context.Points == null)
            {
                return NotFound();
            }
            var points = await _context.Points.FindAsync(id);
            if (points == null)
            {
                return NotFound();
            }

            _context.Points.Remove(points);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //todo-delete [HttpPut("{Spend}", Name = "Spend")]
        [HttpPut]
        public ActionResult<Points> Spend(int TransactionPoints)
        {
            if (_context.Points == null)
            {
                return Problem("Entity set 'PointsContext.PointsRecords'  is null.");
            }
            
            
            //Update Points Entities;
            int tempSpendThesePoints = TransactionPoints;
            List<Points> points = _context.Points.ToList();
            foreach (Points p in points)
            {               
                if(p.TransactionPoints - tempSpendThesePoints < 0)
                {
                    tempSpendThesePoints -= p.TransactionPoints;
                    p.TransactionPoints = 0;
                }
                if (p.TransactionPoints - tempSpendThesePoints >= 0)
                {
                    p.TransactionPoints -= tempSpendThesePoints;
                    tempSpendThesePoints = 0;
                }
            }
            
            _context.SaveChanges();

            return Accepted();
            //return CreatedAtAction("GetPoints", new { id = points.Id }, points);
        }


        //[HttpPut("{Spend}", Name = "Spend")]
        //public async Task<ActionResult<Points>> Spend(int TransactionPoints)
        //{
        //    if (_context.Points == null)
        //    {
        //        return Problem("Entity set 'PointsContext.PointsRecords'  is null.");
        //    }


        //    //Update Points Entities;
        //    int tempSpendThesePoints = TransactionPoints;
        //    List<Points> points = _context.Points.ToList();
        //    foreach (Points p in points)
        //    {
        //        if (p.TransactionPoints - tempSpendThesePoints < 0)
        //        {
        //            tempSpendThesePoints -= p.TransactionPoints;
        //            p.TransactionPoints = 0;
        //        }
        //        if (p.TransactionPoints - tempSpendThesePoints >= 0)
        //        {
        //            p.TransactionPoints -= tempSpendThesePoints;
        //            tempSpendThesePoints = 0;
        //        }

        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok();
        //    //return CreatedAtAction("GetPoints", new { id = points.Id }, points);
        //}

        private bool PointsExists(long id)
        {
            return (_context.Points?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
