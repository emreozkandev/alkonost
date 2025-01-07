using Alkonost.Core.Common;
using System.Collections.Generic;

namespace Alkonost.Core.Entities
{
  public class Traveler : BaseEntity
  {
    public Traveler()
    {
      FirstName = string.Empty;
      LastName = string.Empty;
      Email = string.Empty;
      TravelerTours = new HashSet<TravelerTour>();
      Payments = new HashSet<Payment>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? NationalId { get; set; }
    public string? PassportNumber { get; set; }
    public string Email { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<TravelerTour> TravelerTours { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
  }
}