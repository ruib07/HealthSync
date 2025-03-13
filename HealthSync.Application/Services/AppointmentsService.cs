using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;

namespace HealthSync.Application.Services;

public class AppointmentsService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentsService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<IEnumerable<Appointments>> GetAppointments()
    {
        return await _appointmentRepository.GetAppointments();
    }

    public async Task<Appointments> GetAppointmentById(Guid appointmentId)
    {
        var appointment = await _appointmentRepository.GetAppointmentById(appointmentId);

        if (appointment == null) ErrorHelper.ThrowNotFoundException("Appointment not found.");

        return appointment;
    }

    public async Task<IEnumerable<Appointments>> GetAppointmentsByPatientId(Guid patientId)
    {
        var appointmentsByPatient = await _appointmentRepository.GetAppointmentsByPatientId(patientId);

        if (appointmentsByPatient == null || !appointmentsByPatient.Any()) 
            ErrorHelper.ThrowNotFoundException("No appointments found in this patient!");

        return appointmentsByPatient;
    }

    public async Task<IEnumerable<Appointments>> GetAppointmentsByDoctorId(Guid doctorId)
    {
        var appointmentsByDoctor = await _appointmentRepository.GetAppointmentsByDoctorId(doctorId);

        if (appointmentsByDoctor == null || !appointmentsByDoctor.Any()) 
            ErrorHelper.ThrowNotFoundException("No appointments found in this doctor!");

        return appointmentsByDoctor;
    }

    public async Task<Appointments> CreateAppointment(Appointments appointment)
    {
        return await _appointmentRepository.CreateAppointment(appointment);
    }

    public async Task<Appointments> UpdateAppointment(Guid appointmentId, Appointments updateAppointment)
    {
        var currentAppointment = await GetAppointmentById(appointmentId);

        currentAppointment.PatientId = updateAppointment.PatientId;
        currentAppointment.DoctorId = updateAppointment.DoctorId;
        currentAppointment.AppointmentDateTime = updateAppointment.AppointmentDateTime;
        currentAppointment.Notes = updateAppointment.Notes;
        currentAppointment.Status = updateAppointment.Status;

        await _appointmentRepository.UpdateAppointment(currentAppointment);
        return currentAppointment;
    }

    public async Task DeleteAppointment(Guid appointmentId)
    {
        await _appointmentRepository.DeleteAppointment(appointmentId);
    }
}
