using HealthSync.Infrastructure.Data;
using HealthSync.Infrastructure.Repositories;
using HealthSync.Tests.Templates;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Tests.Repositories;

[TestFixture]
public class DoctorRepositoryTests
{
    private DoctorRepository _doctorRepository;
    private ApplicationDbContext _context;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

        _context = new ApplicationDbContext(options);
        _doctorRepository = new DoctorRepository(_context);
    }

    [TearDown]  
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetDoctors_ReturnsDoctors()
    {
        var doctors = DoctorsTests.CreateDoctors();
        _context.Doctors.AddRange(doctors);
        await _context.SaveChangesAsync();

        var result = await _doctorRepository.GetDoctors();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(doctors[0].Id));
            Assert.That(result.First().Name, Is.EqualTo(doctors[0].Name));
            Assert.That(result.Last().Id, Is.EqualTo(doctors[1].Id));
            Assert.That(result.Last().Name, Is.EqualTo(doctors[1].Name));
        });
    }

    [Test]
    public async Task GetDoctorById_ReturnsDoctor()
    {
        var doctor = DoctorsTests.CreateDoctors().First();

        await _doctorRepository.CreateDoctor(doctor);

        var result = await _doctorRepository.GetDoctorById(doctor.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(doctor.Id));
            Assert.That(result.Name, Is.EqualTo(doctor.Name));
            Assert.That(result.Specialization, Is.EqualTo(doctor.Specialization));
            Assert.That(result.PhoneNumber, Is.EqualTo(doctor.PhoneNumber));
            Assert.That(result.Email, Is.EqualTo(doctor.Email));
            Assert.That(result.LicenseNumber, Is.EqualTo(doctor.LicenseNumber));
        });
    }

    [Test]
    public async Task CreateDoctor_CreatesSuccessfully()
    {
        var newDoctor = DoctorsTests.CreateDoctors().First();

        var result = await _doctorRepository.CreateDoctor(newDoctor);
        var addedDoctor = await _doctorRepository.GetDoctorById(newDoctor.Id);

        Assert.That(addedDoctor, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(addedDoctor.Id, Is.EqualTo(newDoctor.Id));
            Assert.That(addedDoctor.Name, Is.EqualTo(newDoctor.Name));
            Assert.That(addedDoctor.Specialization, Is.EqualTo(newDoctor.Specialization));
            Assert.That(addedDoctor.PhoneNumber, Is.EqualTo(newDoctor.PhoneNumber));
            Assert.That(addedDoctor.Email, Is.EqualTo(newDoctor.Email));
            Assert.That(addedDoctor.LicenseNumber, Is.EqualTo(newDoctor.LicenseNumber));
        });
    }

    [Test]
    public async Task UpdateDoctor_UpdatesSuccessfully()
    {
        var existingDoctor = DoctorsTests.CreateDoctors().First();
        await _doctorRepository.CreateDoctor(existingDoctor);

        _context.Entry(existingDoctor).State = EntityState.Detached;

        var updatedDoctor = DoctorsTests.UpdateDoctor(existingDoctor.Id);

        await _doctorRepository.UpdateDoctor(updatedDoctor);
        var retrievedUpdatedDoctor = await _doctorRepository.GetDoctorById(existingDoctor.Id);

        Assert.That(retrievedUpdatedDoctor, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(retrievedUpdatedDoctor.Id, Is.EqualTo(updatedDoctor.Id));
            Assert.That(retrievedUpdatedDoctor.Name, Is.EqualTo(updatedDoctor.Name));
            Assert.That(retrievedUpdatedDoctor.Specialization, Is.EqualTo(updatedDoctor.Specialization));
            Assert.That(retrievedUpdatedDoctor.PhoneNumber, Is.EqualTo(updatedDoctor.PhoneNumber));
            Assert.That(retrievedUpdatedDoctor.Email, Is.EqualTo(updatedDoctor.Email));
            Assert.That(retrievedUpdatedDoctor.LicenseNumber, Is.EqualTo(updatedDoctor.LicenseNumber));
        });
    }

    [Test]
    public async Task DeleteDoctor_DeletesSuccessfully()
    {
        var existingDoctor = DoctorsTests.CreateDoctors().First();

        await _doctorRepository.CreateDoctor(existingDoctor);
        await _doctorRepository.DeleteDoctor(existingDoctor.Id);
        var retrivedEmptyDoctor = await _doctorRepository.GetDoctorById(existingDoctor.Id);

        Assert.That(retrivedEmptyDoctor, Is.Null);
    }
}
