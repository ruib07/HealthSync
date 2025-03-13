using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;
using HealthSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;
    private DbSet<Appointments> Appointments => _context.Appointments;

    public AppointmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Appointments>> GetAppointments()
    {
        return await Appointments.ToListAsync();
    }

    public async Task<Appointments> GetAppointmentById(Guid appointmentId)
    {
        return await Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
    }

    public async Task<IEnumerable<Appointments>> GetAppointmentsByPatientId(Guid patientId)
    {
        return await Appointments.AsNoTracking().Where(a => a.PatientId == patientId).ToListAsync();
    }

    public async Task<IEnumerable<Appointments>> GetAppointmentsByDoctorId(Guid doctorId)
    {
        return await Appointments.AsNoTracking().Where(a => a.DoctorId == doctorId).ToListAsync();
    }

    public async Task<Appointments> CreateAppointment(Appointments appointment)
    {
        await Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();

        return appointment;
    }

    public async Task UpdateAppointment(Appointments appointment)
    {
        Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAppointment(Guid appointmentId)
    {
        var appointment = await GetAppointmentById(appointmentId);

        Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
    }
}
