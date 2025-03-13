using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;

namespace HealthSync.Application.Services;

public class MedicalRecordsService
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;

    public MedicalRecordsService(IMedicalRecordRepository medicalRecordRepository)
    {
        _medicalRecordRepository = medicalRecordRepository;
    }

    public async Task<IEnumerable<MedicalRecords>> GetMedicalRecords()
    {
        return await _medicalRecordRepository.GetMedicalRecords();
    }

    public async Task<MedicalRecords> GetMedicalRecordById(Guid medicalRecordId)
    {
        var medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);

        if (medicalRecord == null) ErrorHelper.ThrowNotFoundException("Medical record not found.");

        return medicalRecord;
    }

    public async Task<IEnumerable<MedicalRecords>> GetMedicalRecordsByPatientId(Guid patientId)
    {
        var medicalRecordsByPatient = await _medicalRecordRepository.GetMedicalRecordsByPatientId(patientId);

        if (medicalRecordsByPatient == null || !medicalRecordsByPatient.Any()) 
            ErrorHelper.ThrowNotFoundException("No medical records found in this patient!");

        return medicalRecordsByPatient;
    }

    public async Task<MedicalRecords> CreateMedicalRecord(MedicalRecords medicalRecord)
    {
        return await _medicalRecordRepository.CreateMedicalRecord(medicalRecord);
    }

    public async Task<MedicalRecords> UpdateMedicalRecord(Guid medicalRecordId, MedicalRecords updateMedicalRecord)
    {
        var currentMedicalRecord = await GetMedicalRecordById(medicalRecordId);

        currentMedicalRecord.PatientId = updateMedicalRecord.PatientId;
        currentMedicalRecord.DoctorId = updateMedicalRecord.DoctorId;
        currentMedicalRecord.Diagnosis = updateMedicalRecord.Diagnosis;
        currentMedicalRecord.Prescription = updateMedicalRecord.Prescription;
        currentMedicalRecord.RecordDate = updateMedicalRecord.RecordDate;

        await _medicalRecordRepository.UpdateMedicalRecord(currentMedicalRecord);
        return currentMedicalRecord;
    }

    public async Task DeleteMedicalRecord(Guid medicalRecordId)
    {
        await _medicalRecordRepository.DeleteMedicalRecord(medicalRecordId);
    }
}
