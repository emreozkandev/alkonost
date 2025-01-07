using Alkonost.Core.Common;

namespace Alkonost.Core.Entities
{
  public class TravelerTour : BaseEntity
  {
    public TravelerTour()
    {
      CreatedAt = DateTime.UtcNow;
    }

    public int TravelerId { get; set; }
    public int TourId { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual Traveler Traveler { get; set; } = null!;
    public virtual Tour Tour { get; set; } = null!;
  }
}