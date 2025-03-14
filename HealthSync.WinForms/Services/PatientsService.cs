using HealthSync.Domain.Entities;
using System.Net.Http.Json;

namespace HealthSync.WinForms.Services;

public class PatientsService
{
    private readonly HttpClient _httpClient;

    public PatientsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Patients>> GetPatients()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Patients>>("api/v1/patients");
    }

    public async Task<Patients> GetPatientById(Guid patientId)
    {
        return await _httpClient.GetFromJsonAsync<Patients>($"api/v1/patients/{patientId}");
    }
}
