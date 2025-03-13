using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;

namespace HealthSync.Application.Services;

public class DoctorsService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorsService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<IEnumerable<Doctors>> GetDoctors()
    {
        return await _doctorRepository.GetDoctors();
    }

    public async Task<Doctors> GetDoctorById(Guid doctorId)
    {
        var doctor = await _doctorRepository.GetDoctorById(doctorId);

        if (doctor == null) ErrorHelper.ThrowNotFoundException("Doctor not found.");

        return doctor;
    }

    public async Task<Doctors> CreateDoctor(Doctors doctor)
    {
        return await _doctorRepository.CreateDoctor(doctor);
    }

    public async Task<Doctors> UpdateDoctor(Guid doctorId, Doctors updateDoctor)
    {
        var currentDoctor = await GetDoctorById(doctorId);

        currentDoctor.Name = updateDoctor.Name;
        currentDoctor.Specialization = updateDoctor.Specialization;
        currentDoctor.PhoneNumber = updateDoctor.PhoneNumber;
        currentDoctor.Email = updateDoctor.Email;
        currentDoctor.LicenseNumber = updateDoctor.LicenseNumber;

        await _doctorRepository.UpdateDoctor(currentDoctor);
        return currentDoctor;
    }

    public async Task DeleteDoctor(Guid doctorId)
    {
        await _doctorRepository.DeleteDoctor(doctorId);
    }
}
