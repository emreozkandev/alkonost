using Alkonost.Core.Common;
using System;

namespace Alkonost.Core.Entities
{
  public class Payment : BaseEntity
  {
    public int TravelerId { get; set; }
    public int TourId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string? TransactionId { get; set; }

    public virtual Traveler Traveler { get; set; } = null!;
    public virtual Tour Tour { get; set; } = null!;
  }

  public enum PaymentStatus
  {
    Pending,
    Completed,
    Failed,
    Refunded
  }
}