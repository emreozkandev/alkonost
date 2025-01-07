namespace Alkonost.Core.Models
{
  public class Traveler
  {
    public Traveler()
    {
      Name = string.Empty;
      Email = string.Empty;
      CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
  }
}