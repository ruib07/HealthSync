using HealthSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSync.Infrastructure.Configurations;

public class AppointmentsConfig : IEntityTypeConfiguration<Appointments>
{
    public void Configure(EntityTypeBuilder<Appointments> builder)
    {
        builder.ToTable("Appointments");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.PatientId).IsRequired();
        builder.Property(p => p.DoctorId).IsRequired();
        builder.Property(p => p.AppointmentDateTime).IsRequired();
        builder.Property(p => p.Notes).HasColumnType("VARCHAR(MAX)");
        builder.Property(p => p.Status).IsRequired();

        builder.HasOne(p => p.Patient)
               .WithMany()
               .HasForeignKey(p => p.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Doctor)
              .WithMany()
              .HasForeignKey(p => p.DoctorId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
