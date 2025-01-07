namespace Alkonost.Core.Common
{
  public abstract class BaseEntity
  {
    protected BaseEntity()
    {
      CreatedAt = DateTime.UtcNow;
      CreatedBy = "System";
      UpdatedBy = "System";
    }

    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
  }
}