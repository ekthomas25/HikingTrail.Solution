using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikingTrail.Models;

namespace HikingTrail.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TrailsController : ControllerBase
  {
    private readonly HikingTrailContext _db;
    public TrailsController(HikingTrailContext db)
    {
      _db = db;
    }

    // GET: api/trails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Trail>>>Get(string name, string difficulty, double length, string familyFriendly, double distanceFromPdx, string configuration, string season)
    {
      var query = _db.Trails.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      
      if (difficulty != null)
      {
        query = query.Where(entry => entry.Difficulty == difficulty);
      }

      if (length >= 20.0)
      {
        query = query.Where(entry => entry.Length > 20.0 && entry.Length <= 24.9);
      }
      else if (length >= 15.0)
      {
        query = query.Where(entry => entry.Length > 15.0 && entry.Length <= 19.9);
      }
      else if (length >= 10.0)
      {
        query = query.Where(entry => entry.Length > 10.0 && entry.Length <= 14.9);
      }
      else if (length >= 5.0)
      {
        query = query.Where(entry => entry.Length > 5.0 && entry.Length <= 9.9);
      } 
      else if (length <= 4.9 && length >= 0.1)
      {
        query = query.Where(entry => entry.Length <= 4.9);
      }

      if (familyFriendly != null)
      {
        query = query.Where(entry => entry.FamilyFriendly == familyFriendly);
      }

      if (distanceFromPdx != 0.0)
      {
        query = query.Where(entry => entry.DistanceFromPdx == distanceFromPdx);
      }

      if (configuration != null)
      {
        query = query.Where(entry => entry.Configuration == configuration);
      }

      if (season != null)
      {
        query = query.Where(entry => entry.Season == season);
      }

      return await query.ToListAsync();
    }

    // GET: api/trails/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Trail>>GetTrail(int id)
    {
      var trail = await _db.Trails.FindAsync(id);

      if (trail == null)
      {
        return NotFound();
      }

      return trail;
    }

    [HttpPost]
    public async Task<ActionResult<Trail>> Post(Trail trail)
    {
      _db.Trails.Add(trail);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetTrail), new { id = trail.TrailId }, trail);
    }

    // DELETE: api/trails/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrail(int id)
    {
      var trail = await _db.Trails.FindAsync(id);
      if(trail == null)
      {
        return NotFound();
      }

      _db.Trails.Remove(trail);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }

}