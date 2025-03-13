using HealthSync.Domain.Enums;

namespace HealthSync.Domain.Entities;

public class Appointments
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patients Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctors Doctor { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public string Notes { get; set; }
    public AppointmentStatus Status { get; set; }
}
