using HealthSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSync.Infrastructure.Configurations;

public class DoctorsConfig : IEntityTypeConfiguration<Doctors>
{
    public void Configure(EntityTypeBuilder<Doctors> builder)
    {
        builder.ToTable("Doctors");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Specialization).IsRequired().HasMaxLength(100);
        builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(10);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(60);
        builder.Property(p => p.LicenseNumber).IsRequired().HasMaxLength(20);

        builder.HasIndex(p => p.LicenseNumber).IsUnique();
    }
}
