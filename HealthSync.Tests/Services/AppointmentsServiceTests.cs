using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Application.Services;
using HealthSync.Domain.Entities;
using HealthSync.Tests.Templates;
using Moq;
using System.Net;

namespace HealthSync.Tests.Services;

[TestFixture]
public class AppointmentsServiceTests
{
    private Mock<IAppointmentRepository> _appointmentRepositoryMock;
    private AppointmentsService _appointmentsService;

    [SetUp]
    public void Setup()
    {
        _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
        _appointmentsService = new AppointmentsService(_appointmentRepositoryMock.Object);
    }

    [Test]
    public async Task GetAppointments_ReturnsAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointments()).ReturnsAsync(appointments);

        var result = await _appointmentsService.GetAppointments();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(appointments[0].Id));
            Assert.That(result.First().PatientId, Is.EqualTo(appointments[0].PatientId));
            Assert.That(result.First().DoctorId, Is.EqualTo(appointments[0].DoctorId));
            Assert.That(result.Last().Id, Is.EqualTo(appointments[1].Id));
            Assert.That(result.Last().PatientId, Is.EqualTo(appointments[1].PatientId));
            Assert.That(result.Last().DoctorId, Is.EqualTo(appointments[1].DoctorId));
        });
    }

    [Test]
    public async Task GetAppointmentById_ReturnsAppointment()
    {
        var appointment = AppointmentsTests.CreateAppointments().First();

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentById(appointment.Id)).ReturnsAsync(appointment);

        var result = await _appointmentsService.GetAppointmentById(appointment.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(appointment.Id));
            Assert.That(result.PatientId, Is.EqualTo(appointment.PatientId));
            Assert.That(result.DoctorId, Is.EqualTo(appointment.DoctorId));
            Assert.That(result.AppointmentDateTime, Is.EqualTo(appointment.AppointmentDateTime));
            Assert.That(result.Notes, Is.EqualTo(appointment.Notes));
            Assert.That(result.Status, Is.EqualTo(appointment.Status));
        });
    }

    [Test]
    public void GetAppointmentById_ReturnsNotFound_WhenAppointmentNotFound()
    {
        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentById(It.IsAny<Guid>())).ReturnsAsync((Appointments)null);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _appointmentsService.GetAppointmentById(Guid.NewGuid()));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Appointment not found."));
        });
    }

    [Test]
    public async Task GetAppointmentsByPatientId_ReturnsAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();
        var singleAppointmentList = new List<Appointments>() { appointments[0] };

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentsByPatientId(appointments[0].PatientId)).ReturnsAsync(singleAppointmentList);

        var result = await _appointmentsService.GetAppointmentsByPatientId(appointments[0].PatientId);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Id, Is.EqualTo(appointments[0].Id));
            Assert.That(result.First().PatientId, Is.EqualTo(appointments[0].PatientId));
            Assert.That(result.First().DoctorId, Is.EqualTo(appointments[0].DoctorId));
            Assert.That(result.First().AppointmentDateTime, Is.EqualTo(appointments[0].AppointmentDateTime));
            Assert.That(result.First().Notes, Is.EqualTo(appointments[0].Notes));
            Assert.That(result.First().Status, Is.EqualTo(appointments[0].Status));
        });
    }

    [Test]
    public void GetAppointmentsByPatientId_ReturnsNotFound_WhenPatientIdNotFound()
    {
        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentsByPatientId(It.IsAny<Guid>())).ReturnsAsync((List<Appointments>)null);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _appointmentsService.GetAppointmentsByPatientId(Guid.NewGuid()));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("No appointments found in this patient!"));
        });
    }

    [Test]
    public async Task GetAppointmentsByDoctorId_ReturnsAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();
        var singleAppointmentList = new List<Appointments>() { appointments[0] };

        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentsByDoctorId(appointments[0].DoctorId)).ReturnsAsync(singleAppointmentList);

        var result = await _appointmentsService.GetAppointmentsByDoctorId(appointments[0].DoctorId);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Id, Is.EqualTo(appointments[0].Id));
            Assert.That(result.First().PatientId, Is.EqualTo(appointments[0].PatientId));
            Assert.That(result.First().DoctorId, Is.EqualTo(appointments[0].DoctorId));
            Assert.That(result.First().AppointmentDateTime, Is.EqualTo(appointments[0].AppointmentDateTime));
            Assert.That(result.First().Notes, Is.EqualTo(appointments[0].Notes));
            Assert.That(result.First().Status, Is.EqualTo(appointments[0].Status));
        });
    }

    [Test]
    public void GetAppointmentsByDoctorId_ReturnsNotFound_WhenDoctorIdNotFound()
    {
        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentsByDoctorId(It.IsAny<Guid>())).ReturnsAsync((List<Appointments>)null);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _appointmentsService.GetAppointmentsByDoctorId(Guid.NewGuid()));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("No appointments found in this doctor!"));
        });
    }

    [Test]
    public async Task CreateProduct_CreatesSuccessfully()
    {
        var appointment = AppointmentsTests.CreateAppointments().First();

        _appointmentRepositoryMock.Setup(setup => setup.CreateAppointment(appointment)).ReturnsAsync(appointment);

        var result = await _appointmentsService.CreateAppointment(appointment);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(appointment.Id));
            Assert.That(result.PatientId, Is.EqualTo(appointment.PatientId));
            Assert.That(result.DoctorId, Is.EqualTo(appointment.DoctorId));
            Assert.That(result.AppointmentDateTime, Is.EqualTo(appointment.AppointmentDateTime));
            Assert.That(result.Notes, Is.EqualTo(appointment.Notes));
            Assert.That(result.Status, Is.EqualTo(appointment.Status));
        });
    }

    [Test]
    public async Task UpdateAppointment_UpdatesSuccessfully()
    {
        var appointment = AppointmentsTests.CreateAppointments().First();
        var updateAppointment = AppointmentsTests.UpdateAppointment(appointment.Id, appointment.PatientId, appointment.DoctorId);

        _appointmentRepositoryMock.Setup(setup => setup.CreateAppointment(appointment)).ReturnsAsync(appointment);
        _appointmentRepositoryMock.Setup(setup => setup.UpdateAppointment(appointment)).Returns(Task.CompletedTask);
        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentById(appointment.Id)).ReturnsAsync(appointment);

        await _appointmentsService.UpdateAppointment(appointment.Id, updateAppointment);
        var result = await _appointmentsService.GetAppointmentById(appointment.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(updateAppointment.Id));
            Assert.That(result.PatientId, Is.EqualTo(updateAppointment.PatientId));
            Assert.That(result.DoctorId, Is.EqualTo(updateAppointment.DoctorId));
            Assert.That(result.AppointmentDateTime, Is.EqualTo(updateAppointment.AppointmentDateTime));
            Assert.That(result.Notes, Is.EqualTo(updateAppointment.Notes));
            Assert.That(result.Status, Is.EqualTo(updateAppointment.Status));
        });
    }

    [Test]
    public async Task DeleteAppointment_DeletesSuccessfully()
    {
        var appointment = AppointmentsTests.CreateAppointments().First();

        _appointmentRepositoryMock.Setup(setup => setup.CreateAppointment(appointment)).ReturnsAsync(appointment);
        _appointmentRepositoryMock.Setup(setup => setup.DeleteAppointment(appointment.Id)).Returns(Task.CompletedTask);
        _appointmentRepositoryMock.Setup(setup => setup.GetAppointmentById(appointment.Id)).ReturnsAsync((Appointments)null);

        await _appointmentsService.CreateAppointment(appointment);
        await _appointmentsService.DeleteAppointment(appointment.Id);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _appointmentsService.GetAppointmentById(appointment.Id));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Appointment not found."));
        });
    }
}
