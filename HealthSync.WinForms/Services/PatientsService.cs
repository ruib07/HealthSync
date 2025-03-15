using HealthSync.Domain.Entities;
using System.Net;
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

    public async Task<Patients> CreatePatient(Patients patient)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/patients", patient);

        if (response.StatusCode == HttpStatusCode.Created)
        {
            return await response.Content.ReadFromJsonAsync<Patients>();
        }
        else
        {
            throw new Exception($"Error creating patient: {response.ReasonPhrase}");
        }
    }

    public async Task RemovePatient(Guid patientId)
    {
        var response = await _httpClient.DeleteAsync($"api/v1/patients/{patientId}");

        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new Exception($"Error deleting patient: {response.ReasonPhrase}");
        }
    }
}
