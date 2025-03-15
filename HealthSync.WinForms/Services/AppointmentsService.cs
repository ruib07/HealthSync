using HealthSync.Domain.Entities;
using System.Net;
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

    public async Task<Appointments> CreateAppointment(Appointments appointment)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/appointments", appointment);

        if (response.StatusCode == HttpStatusCode.Created)
        {
            return await response.Content.ReadFromJsonAsync<Appointments>();
        }
        else
        {
            throw new Exception($"Error creating appointment: {response.ReasonPhrase}");
        }
    }

    public async Task RemoveAppointment(Guid appointmentId)
    {
        var response = await _httpClient.DeleteAsync($"api/v1/appointments/{appointmentId}");

        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new Exception($"Error deleting appointment: {response.ReasonPhrase}");
        }
    }
}
