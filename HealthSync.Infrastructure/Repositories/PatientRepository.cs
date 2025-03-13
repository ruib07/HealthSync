using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;
using HealthSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;
    private DbSet<Patients> Patients => _context.Patients;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patients>> GetPatients()
    {
        return await Patients.ToListAsync();
    }

    public async Task<Patients> GetPatientById(Guid patientId)
    {
        return await Patients.FirstOrDefaultAsync(p => p.Id == patientId);
    }

    public async Task<Patients> CreatePatient(Patients patient)
    {
        await Patients.AddAsync(patient);
        await _context.SaveChangesAsync();

        return patient;
    }

    public async Task UpdatePatient(Patients patient)
    {
        Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePatient(Guid patientId)
    {
        var patient = await GetPatientById(patientId);

        Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }
}
