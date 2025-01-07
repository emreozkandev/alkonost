using Alkonost.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alkonost.Data.Configurations
{
  public class TourConfiguration : IEntityTypeConfiguration<Tour>
  {
    public void Configure(EntityTypeBuilder<Tour> builder)
    {
      builder.HasKey(t => t.Id);

      builder.Property(t => t.TourName)
          .IsRequired()
          .HasMaxLength(255);

      builder.Property(t => t.Description)
          .HasColumnType("ntext");

      builder.Property(t => t.Price)
          .HasColumnType("decimal(10,2)");

      builder.HasOne(t => t.CreatedByUser)
          .WithMany()
          .HasForeignKey(t => t.CreatedByUserId)
          .OnDelete(DeleteBehavior.Restrict);
    }
  }
}