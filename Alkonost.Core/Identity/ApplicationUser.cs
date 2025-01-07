using Microsoft.AspNetCore.Identity;

namespace Alkonost.Core.Identity
{
  public class ApplicationUser : IdentityUser
  {
    public ApplicationUser()
    {
      FirstName = string.Empty;
      LastName = string.Empty;
      CreatedAt = DateTime.UtcNow;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
  }
}