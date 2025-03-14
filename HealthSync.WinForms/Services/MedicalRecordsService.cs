using HealthSync.Domain.Entities;
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
}
