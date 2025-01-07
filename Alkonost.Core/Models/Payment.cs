namespace Alkonost.Core.Models
{
  public class Payment
  {
    public Payment()
    {
      Description = string.Empty;
      CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime PaymentDate { get; set; }
    public int TravelerId { get; set; }
    public virtual Traveler? Traveler { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
  }
}