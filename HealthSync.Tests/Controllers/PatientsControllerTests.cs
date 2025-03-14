using HealthSync.API.Controllers;
using HealthSync.Application.Interfaces;
using HealthSync.Application.Services;
using HealthSync.Domain.DTOs;
using HealthSync.Domain.Entities;
using HealthSync.Tests.Templates;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HealthSync.Tests.Controllers;

[TestFixture]
public class PatientsControllerTests
{
    private Mock<IPatientRepository> _patientRepositoryMock;
    private PatientsService _patientsService;
    private PatientsController _patientsController;

    [SetUp]
    public void Setup()
    {
        _patientRepositoryMock = new Mock<IPatientRepository>();
        _patientsService = new PatientsService(_patientRepositoryMock.Object);
        _patientsController = new PatientsController(_patientsService);
    }

    [Test]
    public async Task GetPatients_ReturnsOkResult_WithPatients()
    {
        var patients = PatientsTests.CreatePatients();

        _patientRepositoryMock.Setup(setup => setup.GetPatients()).ReturnsAsync(patients);

        var result = await _patientsController.GetPatients();
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as IEnumerable<Patients>;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Count(), Is.EqualTo(2));
            Assert.That(response.First().Id, Is.EqualTo(patients[0].Id));
            Assert.That(response.First().Name, Is.EqualTo(patients[0].Name));
            Assert.That(response.First().DateOfBirth, Is.EqualTo(patients[0].DateOfBirth));
            Assert.That(response.Last().Id, Is.EqualTo(patients[1].Id));
            Assert.That(response.Last().Name, Is.EqualTo(patients[1].Name));
            Assert.That(response.Last().DateOfBirth, Is.EqualTo(patients[1].DateOfBirth));
        });
    }

    [Test]
    public async Task GetPatientById_ReturnsOkResult_WithPatient()
    {
        var patient = PatientsTests.CreatePatients().First();

        _patientRepositoryMock.Setup(setup => setup.GetPatientById(patient.Id)).ReturnsAsync(patient);

        var result = await _patientsController.GetPatientById(patient.Id);
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as Patients;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Id, Is.EqualTo(patient.Id));
            Assert.That(response.Name, Is.EqualTo(patient.Name));
            Assert.That(response.DateOfBirth, Is.EqualTo(patient.DateOfBirth));
            Assert.That(response.PhoneNumber, Is.EqualTo(patient.PhoneNumber));
            Assert.That(response.Email, Is.EqualTo(patient.Email));
            Assert.That(response.Address, Is.EqualTo(patient.Address));
        });
    }

    [Test]
    public async Task CreatePatient_ReturnsCreatedResult_WhenPatientIsCreated()
    {
        var newPatient = PatientsTests.CreatePatients().First();

        _patientRepositoryMock.Setup(setup => setup.CreatePatient(newPatient)).ReturnsAsync(newPatient);

        var result = await _patientsController.CreatePatient(newPatient);
        var createdResult = result.Result as CreatedAtActionResult;
        var response = createdResult.Value as ResponsesDTO.Creation;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(createdResult.StatusCode, Is.EqualTo(201));
            Assert.That(response.Message, Is.EqualTo("Patient created successfully."));
            Assert.That(response.Id, Is.EqualTo(newPatient.Id));
        });
    }

    [Test]
    public async Task UpdatePatient_ReturnsOkResult_WhenPatientIsUpdated()
    {
        var patient = PatientsTests.CreatePatients().First();
        var updatedPatient = PatientsTests.UpdatePatient(patient.Id);

        _patientRepositoryMock.Setup(setup => setup.GetPatientById(patient.Id)).ReturnsAsync(patient);
        _patientRepositoryMock.Setup(setup => setup.UpdatePatient(It.IsAny<Patients>())).Returns(Task.CompletedTask);

        var result = await _patientsController.UpdatePatient(patient.Id, updatedPatient);
        var okResult = result.Result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo("Patient updated successfully."));
        });
    }

    [Test]
    public async Task DeletePatient_ReturnsNoContentResult_WhenPatientIsDeleted()
    {
        var patient = PatientsTests.CreatePatients().First();

        _patientRepositoryMock.Setup(setup => setup.GetPatientById(patient.Id)).ReturnsAsync(patient);
        _patientRepositoryMock.Setup(setup => setup.DeletePatient(patient.Id)).Returns(Task.CompletedTask);

        var result = await _patientsController.DeletePatient(patient.Id);
        var noContentResult = result as NoContentResult;

        Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
    }
}
