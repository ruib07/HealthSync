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
public class DoctorsControllerTests
{
    private Mock<IDoctorRepository> _doctorRepositoryMock;
    private DoctorsService _doctorsService;
    private DoctorsController _doctorsController;

    [SetUp]
    public void Setup()
    {
        _doctorRepositoryMock = new Mock<IDoctorRepository>();
        _doctorsService = new DoctorsService(_doctorRepositoryMock.Object);
        _doctorsController = new DoctorsController(_doctorsService);
    }

    [Test]
    public async Task GetDoctors_ReturnsOkResult_WithDoctors()
    {
        var doctors = DoctorsTests.CreateDoctors();

        _doctorRepositoryMock.Setup(setup => setup.GetDoctors()).ReturnsAsync(doctors);

        var result = await _doctorsController.GetDoctors();
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as IEnumerable<Doctors>;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Count(), Is.EqualTo(2));
            Assert.That(response.First().Id, Is.EqualTo(doctors[0].Id));
            Assert.That(response.First().Name, Is.EqualTo(doctors[0].Name));
            Assert.That(response.First().Specialization, Is.EqualTo(doctors[0].Specialization));
            Assert.That(response.Last().Id, Is.EqualTo(doctors[1].Id));
            Assert.That(response.Last().Name, Is.EqualTo(doctors[1].Name));
            Assert.That(response.Last().Specialization, Is.EqualTo(doctors[1].Specialization));
        });
    }

    [Test]
    public async Task GetDoctorById_ReturnsOkResult_WithDoctor()
    {
        var doctor = DoctorsTests.CreateDoctors().First();

        _doctorRepositoryMock.Setup(setup => setup.GetDoctorById(doctor.Id)).ReturnsAsync(doctor);

        var result = await _doctorsController.GetDoctorById(doctor.Id);
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as Doctors;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Id, Is.EqualTo(doctor.Id));
            Assert.That(response.Name, Is.EqualTo(doctor.Name));
            Assert.That(response.Specialization, Is.EqualTo(doctor.Specialization));
            Assert.That(response.PhoneNumber, Is.EqualTo(doctor.PhoneNumber));
            Assert.That(response.Email, Is.EqualTo(doctor.Email));
            Assert.That(response.LicenseNumber, Is.EqualTo(doctor.LicenseNumber));
        });
    }

    [Test]
    public async Task CreateDoctor_ReturnsCreatedResult_WhenDoctorIsCreated()
    {
        var newDoctor = DoctorsTests.CreateDoctors().First();

        _doctorRepositoryMock.Setup(setup => setup.CreateDoctor(newDoctor)).ReturnsAsync(newDoctor);

        var result = await _doctorsController.CreateDoctor(newDoctor);
        var createdResult = result.Result as CreatedAtActionResult;
        var response = createdResult.Value as ResponsesDTO.Creation;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(createdResult.StatusCode, Is.EqualTo(201));
            Assert.That(response.Message, Is.EqualTo("Doctor created successfully."));
            Assert.That(response.Id, Is.EqualTo(newDoctor.Id));
        });
    }

    [Test]
    public async Task UpdateDoctor_ReturnsOkResult_WhenDoctorIsUpdated()
    {
        var doctor = DoctorsTests.CreateDoctors().First();
        var updatedDoctor = DoctorsTests.UpdateDoctor(doctor.Id);

        _doctorRepositoryMock.Setup(setup => setup.GetDoctorById(doctor.Id)).ReturnsAsync(doctor);
        _doctorRepositoryMock.Setup(setup => setup.UpdateDoctor(It.IsAny<Doctors>())).Returns(Task.CompletedTask);

        var result = await _doctorsController.UpdateDoctor(doctor.Id, updatedDoctor);
        var okResult = result.Result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo("Doctor updated successfully."));
        });
    }

    [Test]
    public async Task DeleteDoctor_ReturnsNoContentResult_WhenDoctorIsDeleted()
    {
        var doctor = DoctorsTests.CreateDoctors().First();

        _doctorRepositoryMock.Setup(setup => setup.GetDoctorById(doctor.Id)).ReturnsAsync(doctor);
        _doctorRepositoryMock.Setup(setup => setup.DeleteDoctor(doctor.Id)).Returns(Task.CompletedTask);

        var result = await _doctorsController.DeleteDoctor(doctor.Id);
        var noContentResult = result as NoContentResult;

        Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
    }
}
