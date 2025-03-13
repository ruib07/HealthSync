using HealthSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSync.Infrastructure.Configurations;

public class PatientsConfig : IEntityTypeConfiguration<Patients>
{
    public void Configure(EntityTypeBuilder<Patients> builder)
    {
        builder.ToTable("Patients");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.DateOfBirth).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(10);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Address).IsRequired().HasColumnType("VARCHAR(MAX)");
    }
}
