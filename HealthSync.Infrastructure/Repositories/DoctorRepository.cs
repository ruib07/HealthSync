using HealthSync.Application.Interfaces;
using HealthSync.Domain.Entities;
using HealthSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;
    private DbSet<Doctors> Doctors => _context.Doctors;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Doctors>> GetDoctors()
    {
        return await Doctors.ToListAsync();
    }

    public async Task<Doctors> GetDoctorById(Guid doctorId)
    {
        return await Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
    }

    public async Task<Doctors> CreateDoctor(Doctors doctor)
    {
        await Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();

        return doctor;
    }

    public async Task UpdateDoctor(Doctors doctor)
    {
        Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDoctor(Guid doctorId)
    {
        var doctor = await GetDoctorById(doctorId);

        Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
    }
}
