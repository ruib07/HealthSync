using HealthSync.Domain.Entities;
using System.Net.Http.Json;

namespace HealthSync.WinForms.Services;

public class AppointmentsService
{
    private readonly HttpClient _httpClient;

    public AppointmentsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Appointments>> GetAppointments()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Appointments>>("api/v1/appointments");
    }
}
