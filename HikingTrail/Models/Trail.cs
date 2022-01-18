namespace HikingTrail.Models
{
  public class Trail
  {
    public int TrailId { get; set; }
    public string Name { get; set; }
    public double Length { get; set; }
    public string Configuration { get; set; }
    public int ElevationGain { get; set; }
    public string Difficulty { get; set; }
    public string FamilyFriendly { get; set; }
    public double DistanceFromPdx { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Season { get; set; }
  }
}