using HealthSync.Domain.Entities;

namespace HealthSync.Application.Interfaces;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointments>> GetAppointments();
    Task<Appointments> GetAppointmentById(Guid appointmentId);
    Task<IEnumerable<Appointments>> GetAppointmentsByPatientId(Guid patientId);
    Task<IEnumerable<Appointments>> GetAppointmentsByDoctorId(Guid doctorId);
    Task<Appointments> CreateAppointment(Appointments appointment);
    Task UpdateAppointment(Appointments appointment);
    Task DeleteAppointment(Guid appointmentId); 
}
