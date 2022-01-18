using Microsoft.EntityFrameworkCore;

namespace HikingTrail.Models
{
  public class HikingTrailContext : DbContext
  {
    public HikingTrailContext(DbContextOptions<HikingTrailContext> options) : base(options)
    {

    }

    public DbSet<Trail> Trails { get; set; }
  }
}