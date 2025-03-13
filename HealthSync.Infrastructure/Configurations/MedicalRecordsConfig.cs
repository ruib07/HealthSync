using HealthSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSync.Infrastructure.Configurations;

public class MedicalRecordsConfig : IEntityTypeConfiguration<MedicalRecords>
{
    public void Configure(EntityTypeBuilder<MedicalRecords> builder)
    {
        builder.ToTable("MedicalRecords");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.PatientId).IsRequired();
        builder.Property(p => p.DoctorId).IsRequired();
        builder.Property(p => p.Diagnosis).IsRequired().HasColumnType("VARCHAR(MAX)");
        builder.Property(p => p.Prescription).IsRequired().HasColumnType("VARCHAR(MAX)");
        builder.Property(p => p.RecordDate).IsRequired();

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
