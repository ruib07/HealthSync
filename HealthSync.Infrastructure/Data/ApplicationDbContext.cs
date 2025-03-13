using HealthSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HealthSync.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Patients> Patients { get; set; }
    public DbSet<Doctors> Doctors { get; set; }
    public DbSet<Appointments> Appointments { get; set; }
    public DbSet<MedicalRecords> MedicalRecords { get; set; }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
