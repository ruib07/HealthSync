using HealthSync.Domain.Entities;
using System.Net.Http.Json;

namespace HealthSync.WinForms.Services;

public class DoctorsService
{
    private readonly HttpClient _httpClient;

    public DoctorsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Doctors>> GetDoctors()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Doctors>>("api/v1/doctors");
    }
}
