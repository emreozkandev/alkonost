using Alkonost.Core.Common;
using Alkonost.Core.Identity;
using Alkonost.Core.Enums;
using System;
using System.Collections.Generic;

namespace Alkonost.Core.Entities
{
  public class Tour : BaseEntity
  {
    public Tour()
    {
      TourName = string.Empty;
      Description = string.Empty;
      Location = string.Empty;
      TravelerTours = new HashSet<TravelerTour>();
      Payments = new HashSet<Payment>();
      TourPermissions = new HashSet<TourPermission>();
    }

    public string TourName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CreatedByUserId { get; set; }
    public TourStatus Status { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }

    public virtual ApplicationUser CreatedByUser { get; set; } = null!;
    public virtual ICollection<TravelerTour> TravelerTours { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<TourPermission> TourPermissions { get; set; }
  }
}