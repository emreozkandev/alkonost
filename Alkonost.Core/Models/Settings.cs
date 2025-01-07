namespace Alkonost.Core.Models
{
  public class Settings
  {
    public Settings()
    {
      PaymentSummaryEmail = string.Empty;
      CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public string PaymentSummaryEmail { get; set; }
    public bool SendDailyReports { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
  }
}