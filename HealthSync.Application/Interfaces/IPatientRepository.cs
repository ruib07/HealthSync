using HealthSync.Domain.Entities;

namespace HealthSync.Application.Interfaces;

public interface IPatientRepository
{
    Task<IEnumerable<Patients>> GetPatients();
    Task<Patients> GetPatientById(Guid patientId);
    Task<Patients> CreatePatient(Patients patient);
    Task UpdatePatient(Patients patient);
    Task DeletePatient(Guid patientId);
}
