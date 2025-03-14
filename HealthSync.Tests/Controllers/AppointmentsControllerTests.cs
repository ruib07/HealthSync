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
public class AppointmentsControllerTests
{
    private Mock<IAppointmentRepository> _appointmentRepositoryMock;
    private AppointmentsService _appointmentsService;
    private AppointmentsController _appointmentsController;

    [SetUp]
    public void Setup()
    {
        _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
        _appointmentsService = new AppointmentsService(_appointmentRepositoryMock.Object);
        _appointmentsController = new AppointmentsController(_appointmentsService);
    }

    [Test]
    public async Task GetAppointments_ReturnsOkResult_WithAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointments()).ReturnsAsync(appointments);

        var result = await _appointmentsController.GetAppointments();
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as IEnumerable<Appointments>;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Count(), Is.EqualTo(2));
            Assert.That(response.First().Id, Is.EqualTo(appointments[0].Id));
            Assert.That(response.First().PatientId, Is.EqualTo(appointments[0].PatientId));
            Assert.That(response.First().DoctorId, Is.EqualTo(appointments[0].DoctorId));
            Assert.That(response.Last().Id, Is.EqualTo(appointments[1].Id));
            Assert.That(response.Last().PatientId, Is.EqualTo(appointments[1].PatientId));
            Assert.That(response.Last().DoctorId, Is.EqualTo(appointments[1].DoctorId));
        });
    }

    [Test]
    public async Task GetAppointmentById_ReturnsOkResult_WithAppointment()
    {
        var appointment = AppointmentsTests.CreateAppointments().First();

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentById(appointment.Id)).ReturnsAsync(appointment);

        var result = await _appointmentsController.GetAppointmentById(appointment.Id);
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as Appointments;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Id, Is.EqualTo(appointment.Id));
            Assert.That(response.PatientId, Is.EqualTo(appointment.PatientId));
            Assert.That(response.DoctorId, Is.EqualTo(appointment.DoctorId));
            Assert.That(response.AppointmentDateTime, Is.EqualTo(appointment.AppointmentDateTime));
            Assert.That(response.Notes, Is.EqualTo(appointment.Notes));
            Assert.That(response.Status, Is.EqualTo(appointment.Status));
        });
    }

    [Test]
    public async Task GetAppointmentsByPatientId_ReturnsOkResult_WithAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();
        var singleAppointmentList = new List<Appointments>() { appointments[0] };

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentsByPatientId(appointments[0].PatientId)).ReturnsAsync(singleAppointmentList);

        var result = await _appointmentsController.GetAppointmentsByPatientId(appointments[0].PatientId);
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as IEnumerable<Appointments>;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().Id, Is.EqualTo(appointments[0].Id));
            Assert.That(response.First().PatientId, Is.EqualTo(appointments[0].PatientId));
            Assert.That(response.First().DoctorId, Is.EqualTo(appointments[0].DoctorId));
            Assert.That(response.First().AppointmentDateTime, Is.EqualTo(appointments[0].AppointmentDateTime));
            Assert.That(response.First().Notes, Is.EqualTo(appointments[0].Notes));
            Assert.That(response.First().Status, Is.EqualTo(appointments[0].Status));
        });
    }

    [Test]
    public async Task GetAppointmentsByDoctorId_ReturnsOkResult_Withappointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();
        var singleAppointmentList = new List<Appointments>() { appointments[0] };

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentsByDoctorId(appointments[0].DoctorId)).ReturnsAsync(singleAppointmentList);

        var result = await _appointmentsController.GetAppointmentsByDoctorId(appointments[0].DoctorId);
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as IEnumerable<Appointments>;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().Id, Is.EqualTo(appointments[0].Id));
            Assert.That(response.First().PatientId, Is.EqualTo(appointments[0].PatientId));
            Assert.That(response.First().DoctorId, Is.EqualTo(appointments[0].DoctorId));
            Assert.That(response.First().AppointmentDateTime, Is.EqualTo(appointments[0].AppointmentDateTime));
            Assert.That(response.First().Notes, Is.EqualTo(appointments[0].Notes));
            Assert.That(response.First().Status, Is.EqualTo(appointments[0].Status));
        });
    }

    [Test]
    public async Task CreateAppointment_ReturnsCreatedResult_WhenAppointmentIsCreated()
    {
        var newAppointment = AppointmentsTests.CreateAppointments().First();

        _appointmentRepositoryMock.Setup(setup => setup.CreateAppointment(newAppointment)).ReturnsAsync(newAppointment);

        var result = await _appointmentsController.CreateAppointment(newAppointment);
        var createdResult = result.Result as CreatedAtActionResult;
        var response = createdResult.Value as ResponsesDTO.Creation;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(createdResult.StatusCode, Is.EqualTo(201));
            Assert.That(response.Message, Is.EqualTo("Appointment created successfully."));
            Assert.That(response.Id, Is.EqualTo(newAppointment.Id));
        });
    }

    [Test]
    public async Task UpdateAppointment_ReturnsOkResult_WhenAppointmentIsUpdated()
    {
        var appointment = AppointmentsTests.CreateAppointments().First();
        var updatedAppointment = AppointmentsTests.UpdateAppointment(appointment.Id, appointment.PatientId, appointment.DoctorId);

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentById(appointment.Id)).ReturnsAsync(appointment);
        _appointmentRepositoryMock.Setup(setup => setup.UpdateAppointment(It.IsAny<Appointments>())).Returns(Task.CompletedTask);

        var result = await _appointmentsController.UpdateAppointment(appointment.Id, updatedAppointment);
        var okResult = result.Result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo("Appointment updated successfully."));
        });
    }

    [Test]
    public async Task DeleteAppointment_ReturnsNoContentResult_WhenAppointmentIsDeleted()
    {
        var appointment = AppointmentsTests.CreateAppointments().First();

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentById(appointment.Id)).ReturnsAsync(appointment);
        _appointmentRepositoryMock.Setup(setup => setup.DeleteAppointment(appointment.Id)).Returns(Task.CompletedTask);

        var result = await _appointmentsController.DeleteAppointment(appointment.Id);
        var noContentResult = result as NoContentResult;

        Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
    }
}
