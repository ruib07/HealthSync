using HealthSync.Domain.Entities;
using HealthSync.Domain.Enums;

namespace HealthSync.Tests.Templates;

public static class AppointmentsTests
{
    public static List<Appointments> CreateAppointments()
    {
        return new List<Appointments>()
        {
            new Appointments()
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                AppointmentDateTime = DateTime.UtcNow,
                Notes = "Appointments 1 Notes Test",
                Status = AppointmentStatus.Scheduled
            },
            new Appointments()
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                AppointmentDateTime = DateTime.UtcNow.AddDays(1),
                Notes = "Appointments 2 Notes Test",
                Status = AppointmentStatus.Completed
            }
        };
    }

    public static Appointments UpdateAppointment(Guid id, Guid patientId, Guid doctorId)
    {
        return new Appointments()
        {
            Id = id,
            PatientId = patientId,
            DoctorId = doctorId,
            AppointmentDateTime = DateTime.UtcNow.AddDays(2),
            Notes = "Appointments Notes Updated",
            Status = AppointmentStatus.Canceled
        };
    }
}
