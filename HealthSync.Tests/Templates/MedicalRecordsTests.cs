using HealthSync.Domain.Entities;

namespace HealthSync.Tests.Templates;

public static class MedicalRecordsTests
{
    public static List<MedicalRecords> CreateMedicalRecords()
    {
        return new List<MedicalRecords>()
        {
            new MedicalRecords()
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Diagnosis = "MedicalRecords 1 Diagnosis Test",
                Prescription = "MedicalRecords 1 Prescription Test",
                RecordDate = DateTime.UtcNow
            },
            new MedicalRecords()
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Diagnosis = "MedicalRecords 2 Diagnosis Test",
                Prescription = "MedicalRecords 2 Prescription Test",
                RecordDate = DateTime.UtcNow.AddDays(1)
            }
        };
    }
    public static MedicalRecords UpdateMedicalRecord(Guid id, Guid patientId, Guid doctorId)
    {
        return new MedicalRecords()
        {
            Id = id,
            PatientId = patientId,
            DoctorId = doctorId,
            Diagnosis = "MedicalRecords Diagnosis Updated",
            Prescription = "MedicalRecords Prescription Updated",
            RecordDate = DateTime.UtcNow.AddDays(2)
        };
    }
}
