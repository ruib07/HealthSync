using HealthSync.Domain.Entities;
using System.Net;
using System.Net.Http.Json;

namespace HealthSync.WinForms.Services;

public class MedicalRecordsService
{
    private readonly HttpClient _httpClient;

    public MedicalRecordsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<MedicalRecords>> GetMedicalRecords()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<MedicalRecords>>("api/v1/medicalrecords");
    }

    public async Task<MedicalRecords> CreateMedicalRecord(MedicalRecords medicalRecord)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/medicalrecords", medicalRecord);

        if (response.StatusCode == HttpStatusCode.Created)
        {
            return await response.Content.ReadFromJsonAsync<MedicalRecords>();
        }
        else
        {
            throw new Exception($"Error creating doctor: {response.ReasonPhrase}");
        }
    }

    public async Task RemoveMedicalRecord(Guid medicalRecordId)
    {
        var response = await _httpClient.DeleteAsync($"api/v1/medicalrecords/{medicalRecordId}");

        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new Exception($"Error deleting medical record: {response.ReasonPhrase}");
        }
    }
}
