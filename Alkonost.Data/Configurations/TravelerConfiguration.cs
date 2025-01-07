using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Alkonost.Core.Entities;

public class TravelerConfiguration : IEntityTypeConfiguration<Traveler>
{
  public void Configure(EntityTypeBuilder<Traveler> builder)
  {
    builder.HasKey(t => t.Id);

    builder.Property(t => t.NationalId)
        .HasMaxLength(11);

    builder.Property(t => t.PassportNumber)
        .HasMaxLength(20);

    builder.Property(t => t.Email)
        .IsRequired()
        .HasMaxLength(255);

    builder.HasIndex(t => t.Email)
        .IsUnique();

    builder.HasIndex(t => t.NationalId)
        .IsUnique()
        .HasFilter("[NationalId] IS NOT NULL");

    builder.HasIndex(t => t.PassportNumber)
        .IsUnique()
        .HasFilter("[PassportNumber] IS NOT NULL");
  }
}