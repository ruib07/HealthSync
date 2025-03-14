using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Application.Services;
using HealthSync.Domain.Entities;
using HealthSync.Tests.Templates;
using Moq;
using System.Net;

namespace HealthSync.Tests.Services;

[TestFixture]
public class DoctorsServiceTests
{
    private Mock<IDoctorRepository> _doctorRepositoryMock;
    private DoctorsService _doctorsService;

    [SetUp]
    public void Setup()
    {
        _doctorRepositoryMock = new Mock<IDoctorRepository>();
        _doctorsService = new DoctorsService(_doctorRepositoryMock.Object);
    }

    [Test]
    public async Task GetDoctors_ReturnsDoctors()
    {
        var doctors = DoctorsTests.CreateDoctors();

        _doctorRepositoryMock.Setup(setup => setup.GetDoctors()).ReturnsAsync(doctors);

        var result = await _doctorsService.GetDoctors();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(doctors[0].Id));
            Assert.That(result.First().Name, Is.EqualTo(doctors[0].Name));
            Assert.That(result.First().Specialization, Is.EqualTo(doctors[0].Specialization));
            Assert.That(result.Last().Id, Is.EqualTo(doctors[1].Id));
            Assert.That(result.Last().Name, Is.EqualTo(doctors[1].Name));
            Assert.That(result.Last().Specialization, Is.EqualTo(doctors[1].Specialization));
        });
    }

    [Test]
    public async Task GetDoctorById_ReturnsDoctor()
    {
        var doctor = DoctorsTests.CreateDoctors().First();

        _doctorRepositoryMock.Setup(setup => setup.GetDoctorById(doctor.Id)).ReturnsAsync(doctor);

        var result = await _doctorsService.GetDoctorById(doctor.Id);

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
    public void GetDoctorById_ReturnsNotFound_WhenDoctorNotFound()
    {
        _doctorRepositoryMock.Setup(setup => setup.GetDoctorById(It.IsAny<Guid>())).ReturnsAsync((Doctors)null);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _doctorsService.GetDoctorById(Guid.NewGuid()));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Doctor not found."));
        });
    }

    [Test]
    public async Task CreateDoctor_CreatesSuccessfully()
    {
        var doctor = DoctorsTests.CreateDoctors().First();

        _doctorRepositoryMock.Setup(setup => setup.CreateDoctor(doctor)).ReturnsAsync(doctor);

        var result = await _doctorsService.CreateDoctor(doctor);

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
    public async Task UpdateDoctor_UpdatesSuccessfully()
    {
        var doctor = DoctorsTests.CreateDoctors().First();
        var updateDoctor = DoctorsTests.UpdateDoctor(doctor.Id);

        _doctorRepositoryMock.Setup(setup => setup.CreateDoctor(doctor)).ReturnsAsync(doctor);
        _doctorRepositoryMock.Setup(setup => setup.UpdateDoctor(doctor)).Returns(Task.CompletedTask);
        _doctorRepositoryMock.Setup(setup => setup.GetDoctorById(doctor.Id)).ReturnsAsync(doctor);

        await _doctorsService.UpdateDoctor(doctor.Id, updateDoctor);
        var result = await _doctorsService.GetDoctorById(doctor.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(updateDoctor.Id));
            Assert.That(result.Name, Is.EqualTo(updateDoctor.Name));
            Assert.That(result.Specialization, Is.EqualTo(doctor.Specialization));
            Assert.That(result.PhoneNumber, Is.EqualTo(doctor.PhoneNumber));
            Assert.That(result.Email, Is.EqualTo(doctor.Email));
            Assert.That(result.LicenseNumber, Is.EqualTo(doctor.LicenseNumber));
        });
    }

    [Test]
    public async Task DeleteDoctor_DeletesSuccessfully()
    {
        var doctor = DoctorsTests.CreateDoctors().First();

        _doctorRepositoryMock.Setup(setup => setup.CreateDoctor(doctor)).ReturnsAsync(doctor);
        _doctorRepositoryMock.Setup(setup => setup.DeleteDoctor(doctor.Id)).Returns(Task.CompletedTask);
        _doctorRepositoryMock.Setup(setup => setup.GetDoctorById(doctor.Id)).ReturnsAsync((Doctors)null);

        await _doctorsService.CreateDoctor(doctor);
        await _doctorsService.DeleteDoctor(doctor.Id);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _doctorsService.GetDoctorById(doctor.Id));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Doctor not found."));
        });
    }
}
