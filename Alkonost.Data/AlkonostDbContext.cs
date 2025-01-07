using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Alkonost.Core.Entities;
using Alkonost.Core.Identity;
using Alkonost.Core.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonost.Data
{
  public class AlkonostDbContext : IdentityDbContext<ApplicationUser>
  {
    public AlkonostDbContext(DbContextOptions<AlkonostDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tour> Tours { get; set; } = null!;
    public DbSet<Traveler> Travelers { get; set; } = null!;
    public DbSet<TravelerTour> TravelerTours { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<TourPermission> TourPermissions { get; set; } = null!;
    public DbSet<Settings> Settings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.ApplyConfigurationsFromAssembly(typeof(AlkonostDbContext).Assembly);
    }
  }
}