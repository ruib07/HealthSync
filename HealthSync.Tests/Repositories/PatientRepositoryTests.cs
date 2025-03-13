using HealthSync.Infrastructure.Data;
using HealthSync.Infrastructure.Repositories;
using HealthSync.Tests.Templates;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Tests.Repositories;

[TestFixture]
public class PatientRepositoryTests
{
    private PatientRepository _patientRepository;
    private ApplicationDbContext _context;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

        _context = new ApplicationDbContext(options);
        _patientRepository = new PatientRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetPatients_ReturnsPatients()
    {
        var patients = PatientsTests.CreatePatients();
        _context.Patients.AddRange(patients);
        await _context.SaveChangesAsync();

        var result = await _patientRepository.GetPatients();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(patients[0].Id));
            Assert.That(result.First().Name, Is.EqualTo(patients[0].Name));
            Assert.That(result.Last().Id, Is.EqualTo(patients[1].Id));
            Assert.That(result.Last().Name, Is.EqualTo(patients[1].Name));
        });
    }

    [Test]
    public async Task GetPatientById_ReturnsPatient()
    {
        var patient = PatientsTests.CreatePatients().First();

        await _patientRepository.CreatePatient(patient);

        var result = await _patientRepository.GetPatientById(patient.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(patient.Id));
            Assert.That(result.Name, Is.EqualTo(patient.Name));
            Assert.That(result.DateOfBirth, Is.EqualTo(patient.DateOfBirth));
            Assert.That(result.PhoneNumber, Is.EqualTo(patient.PhoneNumber));
            Assert.That(result.Email, Is.EqualTo(patient.Email));
            Assert.That(result.Address, Is.EqualTo(patient.Address));
        });
    }

    [Test]
    public async Task CreatePatient_CreatesSuccessfully()
    {
        var newPatient = PatientsTests.CreatePatients().First();

        var result = await _patientRepository.CreatePatient(newPatient);
        var addedPatient = await _patientRepository.GetPatientById(newPatient.Id);

        Assert.That(addedPatient, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(addedPatient.Id, Is.EqualTo(newPatient.Id));
            Assert.That(addedPatient.Name, Is.EqualTo(newPatient.Name));
            Assert.That(addedPatient.DateOfBirth, Is.EqualTo(newPatient.DateOfBirth));
            Assert.That(addedPatient.PhoneNumber, Is.EqualTo(newPatient.PhoneNumber));
            Assert.That(addedPatient.Email, Is.EqualTo(newPatient.Email));
            Assert.That(addedPatient.Address, Is.EqualTo(newPatient.Address));
        });
    }

    [Test]
    public async Task UpdatePatient_UpdatesSuccessfully()
    {
        var existingPatient = PatientsTests.CreatePatients().First();
        await _patientRepository.CreatePatient(existingPatient);

        _context.Entry(existingPatient).State = EntityState.Detached;

        var updatedPatient = PatientsTests.UpdatePatient(existingPatient.Id);

        await _patientRepository.UpdatePatient(updatedPatient);
        var retrievedUpdatedPatient = await _patientRepository.GetPatientById(existingPatient.Id);

        Assert.That(retrievedUpdatedPatient, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(retrievedUpdatedPatient.Id, Is.EqualTo(updatedPatient.Id));
            Assert.That(retrievedUpdatedPatient.Name, Is.EqualTo(updatedPatient.Name));
            Assert.That(retrievedUpdatedPatient.DateOfBirth, Is.EqualTo(updatedPatient.DateOfBirth));
            Assert.That(retrievedUpdatedPatient.PhoneNumber, Is.EqualTo(updatedPatient.PhoneNumber));
            Assert.That(retrievedUpdatedPatient.Email, Is.EqualTo(updatedPatient.Email));
            Assert.That(retrievedUpdatedPatient.Address, Is.EqualTo(updatedPatient.Address));
        });
    }

    [Test]
    public async Task DeletePatient_DeletesSuccessfully()
    {
        var existingPatient = PatientsTests.CreatePatients().First();

        await _patientRepository.CreatePatient(existingPatient);
        await _patientRepository.DeletePatient(existingPatient.Id);
        var retrivedEmptyPatient = await _patientRepository.GetPatientById(existingPatient.Id);

        Assert.That(retrivedEmptyPatient, Is.Null);
    }
}
