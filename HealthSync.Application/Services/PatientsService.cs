using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;

namespace HealthSync.Application.Services;

public class PatientsService
{
    private readonly IPatientRepository _patientRepository;

    public PatientsService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<Patients>> GetPatients()
    {
        return await _patientRepository.GetPatients();
    }

    public async Task<Patients> GetPatientById(Guid patientId)
    {
        var patient = await _patientRepository.GetPatientById(patientId);

        if (patient == null) ErrorHelper.ThrowNotFoundException("Patient not found.");

        return patient;
    }

    public async Task<Patients> CreatePatient(Patients patient)
    {
        return await _patientRepository.CreatePatient(patient);
    }

    public async Task<Patients> UpdatePatient(Guid patientId, Patients updatePatient)
    {
        var currentPatient = await GetPatientById(patientId);

        currentPatient.Name = updatePatient.Name;
        currentPatient.DateOfBirth = updatePatient.DateOfBirth;
        currentPatient.PhoneNumber = updatePatient.PhoneNumber;
        currentPatient.Email = updatePatient.Email;
        currentPatient.Address = updatePatient.Address;

        await _patientRepository.UpdatePatient(currentPatient);
        return currentPatient;
    }

    public async Task DeletePatient(Guid patientId)
    {
        await _patientRepository.DeletePatient(patientId);
    }
}
