using Alkonost.Core.Common;
using Alkonost.Core.Identity;
using Alkonost.Core.Enums;
using System;

namespace Alkonost.Core.Entities
{
  public class TourPermission : BaseEntity
  {
    public TourPermission()
    {
      GrantedAt = DateTime.UtcNow;
    }

    public string UserId { get; set; } = null!;
    public int TourId { get; set; }
    public PermissionType PermissionType { get; set; }
    public DateTime GrantedAt { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
    public virtual Tour Tour { get; set; } = null!;
  }
}