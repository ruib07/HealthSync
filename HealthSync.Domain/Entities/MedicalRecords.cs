namespace HealthSync.Domain.Entities;

public class MedicalRecords
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patients Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctors Doctor { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
    public DateTime RecordDate { get; set; }
}
