using Alkonost.Core.Common;

namespace Alkonost.Core.Entities
{
  public class Settings : BaseEntity
  {
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsSystem { get; set; }
  }
}