using HealthSync.Domain.Entities;

namespace HealthSync.Application.Interfaces;

public interface IMedicalRecordRepository
{
    Task<IEnumerable<MedicalRecords>> GetMedicalRecords(); 
    Task<MedicalRecords> GetMedicalRecordById(Guid medicalRecordId);
    Task<IEnumerable<MedicalRecords>> GetMedicalRecordsByPatientId(Guid patientId);
    Task<MedicalRecords> CreateMedicalRecord(MedicalRecords medicalRecord);
    Task UpdateMedicalRecord(MedicalRecords medicalRecord);
    Task DeleteMedicalRecord(Guid medicalRecordId); 
}
