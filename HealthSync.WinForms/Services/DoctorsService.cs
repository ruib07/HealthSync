using HealthSync.Domain.Entities;
using System.Net;
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

    public async Task<Doctors> GetDoctorById(Guid doctorId)
    {
        return await _httpClient.GetFromJsonAsync<Doctors>($"api/v1/doctors/{doctorId}");
    }

    public async Task<Doctors> CreateDoctor(Doctors doctor)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/doctors", doctor);

        if (response.StatusCode == HttpStatusCode.Created) return await response.Content.ReadFromJsonAsync<Doctors>();
        
        else throw new Exception($"Error creating doctor: {response.ReasonPhrase}");   
    }

    public async Task<Doctors> EditDoctor(Guid doctorId, Doctors editDoctor)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/v1/doctors/{doctorId}", editDoctor);

        if (response.StatusCode == HttpStatusCode.OK) return editDoctor;

        else throw new Exception($"Error updating doctor: {response.ReasonPhrase}");
    }

    public async Task RemoveDoctor(Guid doctorId)
    {
        var response = await _httpClient.DeleteAsync($"api/v1/doctors/{doctorId}");

        if (response.StatusCode != HttpStatusCode.NoContent)
            throw new Exception($"Error deleting doctor: {response.ReasonPhrase}");
    }
}
