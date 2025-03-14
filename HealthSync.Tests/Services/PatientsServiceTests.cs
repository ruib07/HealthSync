using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Application.Services;
using HealthSync.Domain.Entities;
using HealthSync.Tests.Templates;
using Moq;
using System.Net;

namespace HealthSync.Tests.Services;

[TestFixture]
public class PatientsServiceTests
{
    private Mock<IPatientRepository> _patientRepositoryMock;
    private PatientsService _patientsService;

    [SetUp]
    public void Setup()
    {
        _patientRepositoryMock = new Mock<IPatientRepository>();
        _patientsService = new PatientsService(_patientRepositoryMock.Object);
    }

    [Test]
    public async Task GetPatients_ReturnsPatients()
    {
        var patients = PatientsTests.CreatePatients();

        _patientRepositoryMock.Setup(setup => setup.GetPatients()).ReturnsAsync(patients);

        var result = await _patientsService.GetPatients();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(patients[0].Id));
            Assert.That(result.First().Name, Is.EqualTo(patients[0].Name));
            Assert.That(result.First().DateOfBirth, Is.EqualTo(patients[0].DateOfBirth));
            Assert.That(result.Last().Id, Is.EqualTo(patients[1].Id));
            Assert.That(result.Last().Name, Is.EqualTo(patients[1].Name));
            Assert.That(result.Last().DateOfBirth, Is.EqualTo(patients[1].DateOfBirth));
        });
    }

    [Test]
    public async Task GetPatientById_ReturnsPatient()
    {
        var patient = PatientsTests.CreatePatients().First();

        _patientRepositoryMock.Setup(setup => setup.GetPatientById(patient.Id)).ReturnsAsync(patient);

        var result = await _patientsService.GetPatientById(patient.Id);

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
    public void GetPatientById_ReturnsNotFound_WhenPatientNotFound()
    {
        _patientRepositoryMock.Setup(setup => setup.GetPatientById(It.IsAny<Guid>())).ReturnsAsync((Patients)null);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _patientsService.GetPatientById(Guid.NewGuid()));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Patient not found."));
        });
    }

    [Test]
    public async Task CreatePatient_CreatesSuccessfully()
    {
        var patient = PatientsTests.CreatePatients().First();

        _patientRepositoryMock.Setup(setup => setup.CreatePatient(patient)).ReturnsAsync(patient);

        var result = await _patientsService.CreatePatient(patient);

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
    public async Task UpdatePatient_UpdatesSuccessfully()
    {
        var patient = PatientsTests.CreatePatients().First();
        var updatePatient = PatientsTests.UpdatePatient(patient.Id);

        _patientRepositoryMock.Setup(setup => setup.CreatePatient(patient)).ReturnsAsync(patient);
        _patientRepositoryMock.Setup(setup => setup.UpdatePatient(patient)).Returns(Task.CompletedTask);
        _patientRepositoryMock.Setup(setup => setup.GetPatientById(patient.Id)).ReturnsAsync(patient);

        await _patientsService.UpdatePatient(patient.Id, updatePatient);
        var result = await _patientsService.GetPatientById(patient.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(updatePatient.Id));
            Assert.That(result.Name, Is.EqualTo(updatePatient.Name));
            Assert.That(result.DateOfBirth, Is.EqualTo(patient.DateOfBirth));
            Assert.That(result.PhoneNumber, Is.EqualTo(patient.PhoneNumber));
            Assert.That(result.Email, Is.EqualTo(patient.Email));
            Assert.That(result.Address, Is.EqualTo(patient.Address));
        });
    }

    [Test]
    public async Task DeletePatient_DeletesSuccessfully()
    {
        var patient = PatientsTests.CreatePatients().First();

        _patientRepositoryMock.Setup(setup => setup.CreatePatient(patient)).ReturnsAsync(patient);
        _patientRepositoryMock.Setup(setup => setup.DeletePatient(patient.Id)).Returns(Task.CompletedTask);
        _patientRepositoryMock.Setup(setup => setup.GetPatientById(patient.Id)).ReturnsAsync((Patients)null);

        await _patientsService.CreatePatient(patient);
        await _patientsService.DeletePatient(patient.Id);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _patientsService.GetPatientById(patient.Id));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Patient not found."));
        });
    }
}
