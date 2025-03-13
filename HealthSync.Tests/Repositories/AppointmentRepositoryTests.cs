using HealthSync.Infrastructure.Data;
using HealthSync.Infrastructure.Repositories;
using HealthSync.Tests.Templates;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Tests.Repositories;

[TestFixture]
public class AppointmentRepositoryTests
{
    private AppointmentRepository _appointmentRepository;
    private ApplicationDbContext _context;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

        _context = new ApplicationDbContext(options);
        _appointmentRepository = new AppointmentRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetAppointments_ReturnsAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();
        _context.Appointments.AddRange(appointments);
        await _context.SaveChangesAsync();

        var result = await _appointmentRepository.GetAppointments();

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
        await _appointmentRepository.CreateAppointment(appointment);

        var result = await _appointmentRepository.GetAppointmentById(appointment.Id);

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
    public async Task GetAppointmentsByPatientId_ReturnsAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();
        _context.Appointments.AddRange(appointments);
        await _context.SaveChangesAsync();

        var result = await _appointmentRepository.GetAppointmentsByPatientId(appointments[0].PatientId);

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
    public async Task GetAppointmentsByDoctorId_ReturnsAppointments()
    {
        var appointments = AppointmentsTests.CreateAppointments();
        _context.Appointments.AddRange(appointments);
        await _context.SaveChangesAsync();

        var result = await _appointmentRepository.GetAppointmentsByDoctorId(appointments[0].DoctorId);

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
    public async Task CreateAppointment_CreatesSuccessfully()
    {
        var newAppointment = AppointmentsTests.CreateAppointments().First();

        var result = await _appointmentRepository.CreateAppointment(newAppointment);
        var addedAppointment = await _appointmentRepository.GetAppointmentById(newAppointment.Id);

        Assert.That(addedAppointment, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(addedAppointment.Id, Is.EqualTo(newAppointment.Id));
            Assert.That(addedAppointment.PatientId, Is.EqualTo(newAppointment.PatientId));
            Assert.That(addedAppointment.DoctorId, Is.EqualTo(newAppointment.DoctorId));
            Assert.That(addedAppointment.AppointmentDateTime, Is.EqualTo(newAppointment.AppointmentDateTime));
            Assert.That(addedAppointment.Notes, Is.EqualTo(newAppointment.Notes));
            Assert.That(addedAppointment.Status, Is.EqualTo(newAppointment.Status));
        });
    }

    [Test]
    public async Task UpdateAppointment_UpdatesSuccessfully()
    {
        var existingAppointment = AppointmentsTests.CreateAppointments().First();
        await _appointmentRepository.CreateAppointment(existingAppointment);

        _context.Entry(existingAppointment).State = EntityState.Detached;

        var updatedAppointment = AppointmentsTests.UpdateAppointment(
            existingAppointment.Id, existingAppointment.PatientId, existingAppointment.DoctorId);

        await _appointmentRepository.UpdateAppointment(updatedAppointment);
        var retrievedUpdatedAppointment = await _appointmentRepository.GetAppointmentById(existingAppointment.Id);

        Assert.That(retrievedUpdatedAppointment, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(retrievedUpdatedAppointment.Id, Is.EqualTo(updatedAppointment.Id));
            Assert.That(retrievedUpdatedAppointment.PatientId, Is.EqualTo(updatedAppointment.PatientId));
            Assert.That(retrievedUpdatedAppointment.DoctorId, Is.EqualTo(updatedAppointment.DoctorId));
            Assert.That(retrievedUpdatedAppointment.AppointmentDateTime, Is.EqualTo(updatedAppointment.AppointmentDateTime));
            Assert.That(retrievedUpdatedAppointment.Notes, Is.EqualTo(updatedAppointment.Notes));
            Assert.That(retrievedUpdatedAppointment.Status, Is.EqualTo(updatedAppointment.Status));
        });
    }

    [Test]
    public async Task DeleteAppointment_DeletesSuccessfully()
    {
        var existingAppointment = AppointmentsTests.CreateAppointments().First();

        await _appointmentRepository.CreateAppointment(existingAppointment);
        await _appointmentRepository.DeleteAppointment(existingAppointment.Id);
        var retrivedEmptyAppointment = await _appointmentRepository.GetAppointmentById(existingAppointment.Id);

        Assert.That(retrivedEmptyAppointment, Is.Null);
    }
}
