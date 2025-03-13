using HealthSync.Domain.Entities;

namespace HealthSync.Application.Interfaces;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctors>> GetDoctors();
    Task<Doctors> GetDoctorById(Guid doctorId);
    Task<Doctors> CreateDoctor(Doctors doctor);
    Task UpdateDoctor(Doctors doctor);
    Task DeleteDoctor(Guid doctorId);
}
