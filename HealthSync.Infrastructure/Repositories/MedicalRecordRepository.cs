using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;
using HealthSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Infrastructure.Repositories;

public class MedicalRecordRepository : IMedicalRecordRepository
{
    private readonly ApplicationDbContext _context;
    private DbSet<MedicalRecords> MedicalRecords => _context.MedicalRecords;

    public MedicalRecordRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MedicalRecords>> GetMedicalRecords()
    {
        return await MedicalRecords.ToListAsync();
    }

    public async Task<MedicalRecords> GetMedicalRecordById(Guid medicalRecordId)
    {
        return await MedicalRecords.FirstOrDefaultAsync(mr => mr.Id == medicalRecordId);
    }

    public async Task<IEnumerable<MedicalRecords>> GetMedicalRecordsByPatientId(Guid patientId)
    {
        return await MedicalRecords.AsNoTracking().Where(mr => mr.PatientId == patientId).ToListAsync();
    }

    public async Task<MedicalRecords> CreateMedicalRecord(MedicalRecords medicalRecord)
    {
        await MedicalRecords.AddAsync(medicalRecord);
        await _context.SaveChangesAsync();

        return medicalRecord;
    }

    public async Task UpdateMedicalRecord(MedicalRecords medicalRecord)
    {
        MedicalRecords.Update(medicalRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMedicalRecord(Guid medicalRecordId)
    {
        var medicalRecord = await GetMedicalRecordById(medicalRecordId);

        MedicalRecords.Remove(medicalRecord);
        await _context.SaveChangesAsync();
    }
}
