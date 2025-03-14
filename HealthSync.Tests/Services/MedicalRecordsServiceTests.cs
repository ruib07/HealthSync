using HealthSync.Application.Helpers;
using HealthSync.Application.Interfaces;
using HealthSync.Application.Services;
using HealthSync.Domain.Entities;
using HealthSync.Tests.Templates;
using Moq;
using System.Net;

namespace HealthSync.Tests.Services;

[TestFixture]
public class MedicalRecordsServiceTests
{
    private Mock<IMedicalRecordRepository> _medicalRecordsetupsitoryMock;
    private MedicalRecordsService _medicalRecordsService;

    [SetUp]
    public void Setup()
    {
        _medicalRecordsetupsitoryMock = new Mock<IMedicalRecordRepository>();
        _medicalRecordsService = new MedicalRecordsService(_medicalRecordsetupsitoryMock.Object);
    }

    [Test]
    public async Task GetMedicalRecords_ReturnsMedicalRecords()
    {
        var medicalRecords = MedicalRecordsTests.CreateMedicalRecords();

        _medicalRecordsetupsitoryMock.Setup(setup => setup.GetMedicalRecords()).ReturnsAsync(medicalRecords);

        var result = await _medicalRecordsService.GetMedicalRecords();

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(medicalRecords[0].Id));
            Assert.That(result.First().PatientId, Is.EqualTo(medicalRecords[0].PatientId));
            Assert.That(result.First().DoctorId, Is.EqualTo(medicalRecords[0].DoctorId));
            Assert.That(result.Last().Id, Is.EqualTo(medicalRecords[1].Id));
            Assert.That(result.Last().PatientId, Is.EqualTo(medicalRecords[1].PatientId));
            Assert.That(result.Last().DoctorId, Is.EqualTo(medicalRecords[1].DoctorId));
        });
    }

    [Test]
    public async Task GetMedicalRecordById_ReturnsMedicalRecord()
    {
        var medicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();

        _medicalRecordsetupsitoryMock.Setup(setup => setup.GetMedicalRecordById(medicalRecord.Id)).ReturnsAsync(medicalRecord);

        var result = await _medicalRecordsService.GetMedicalRecordById(medicalRecord.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(medicalRecord.Id));
            Assert.That(result.PatientId, Is.EqualTo(medicalRecord.PatientId));
            Assert.That(result.DoctorId, Is.EqualTo(medicalRecord.DoctorId));
            Assert.That(result.Diagnosis, Is.EqualTo(medicalRecord.Diagnosis));
            Assert.That(result.Prescription, Is.EqualTo(medicalRecord.Prescription));
            Assert.That(result.RecordDate, Is.EqualTo(medicalRecord.RecordDate));
        });
    }

    [Test]
    public void GetMedicalRecordById_ReturnsNotFound_WhenMedicalRecordNotFound()
    {
        _medicalRecordsetupsitoryMock.Setup(setup => setup.GetMedicalRecordById(It.IsAny<Guid>())).ReturnsAsync((MedicalRecords)null);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _medicalRecordsService.GetMedicalRecordById(Guid.NewGuid()));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Medical record not found."));
        });
    }

    [Test]
    public async Task GetMedicalRecordsByPatientId_ReturnsMedicalRecords()
    {
        var medicalRecords = MedicalRecordsTests.CreateMedicalRecords();
        var singleMedicalRecordsList = new List<MedicalRecords>() { medicalRecords[0] };

        _medicalRecordsetupsitoryMock.Setup(setup => setup.GetMedicalRecordsByPatientId(medicalRecords[0].PatientId)).ReturnsAsync(singleMedicalRecordsList);

        var result = await _medicalRecordsService.GetMedicalRecordsByPatientId(medicalRecords[0].PatientId);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Id, Is.EqualTo(medicalRecords[0].Id));
            Assert.That(result.First().PatientId, Is.EqualTo(medicalRecords[0].PatientId));
            Assert.That(result.First().DoctorId, Is.EqualTo(medicalRecords[0].DoctorId));
            Assert.That(result.First().Diagnosis, Is.EqualTo(medicalRecords[0].Diagnosis));
            Assert.That(result.First().Prescription, Is.EqualTo(medicalRecords[0].Prescription));
            Assert.That(result.First().RecordDate, Is.EqualTo(medicalRecords[0].RecordDate));
        });
    }

    [Test]
    public void GetMedicalRecordsByPatientId_ReturnsNotFound_WhenPatientIdNotFound()
    {
        _medicalRecordsetupsitoryMock.Setup(setup => setup.GetMedicalRecordsByPatientId(It.IsAny<Guid>())).ReturnsAsync((List<MedicalRecords>)null);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _medicalRecordsService.GetMedicalRecordsByPatientId(Guid.NewGuid()));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("No medical records found in this patient!"));
        });
    }

    [Test]
    public async Task CreateMedicalRecord_CreatesSuccessfully()
    {
        var medicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();

        _medicalRecordsetupsitoryMock.Setup(setup => setup.CreateMedicalRecord(medicalRecord)).ReturnsAsync(medicalRecord);

        var result = await _medicalRecordsService.CreateMedicalRecord(medicalRecord);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(medicalRecord.Id));
            Assert.That(result.PatientId, Is.EqualTo(medicalRecord.PatientId));
            Assert.That(result.DoctorId, Is.EqualTo(medicalRecord.DoctorId));
            Assert.That(result.Diagnosis, Is.EqualTo(medicalRecord.Diagnosis));
            Assert.That(result.Prescription, Is.EqualTo(medicalRecord.Prescription));
            Assert.That(result.RecordDate, Is.EqualTo(medicalRecord.RecordDate));
        });
    }

    [Test]
    public async Task UpdateMedicalRecord_UpdatesSuccessfully()
    {
        var medicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();
        var updateMedicalRecord = MedicalRecordsTests.UpdateMedicalRecord(medicalRecord.Id, medicalRecord.PatientId, medicalRecord.DoctorId);

        _medicalRecordsetupsitoryMock.Setup(setup => setup.CreateMedicalRecord(medicalRecord)).ReturnsAsync(medicalRecord);
        _medicalRecordsetupsitoryMock.Setup(setup => setup.UpdateMedicalRecord(medicalRecord)).Returns(Task.CompletedTask);
        _medicalRecordsetupsitoryMock.Setup(setup => setup.GetMedicalRecordById(medicalRecord.Id)).ReturnsAsync(medicalRecord);

        await _medicalRecordsService.UpdateMedicalRecord(medicalRecord.Id, updateMedicalRecord);
        var result = await _medicalRecordsService.GetMedicalRecordById(medicalRecord.Id);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(updateMedicalRecord.Id));
            Assert.That(result.PatientId, Is.EqualTo(medicalRecord.PatientId));
            Assert.That(result.DoctorId, Is.EqualTo(medicalRecord.DoctorId));
            Assert.That(result.Diagnosis, Is.EqualTo(medicalRecord.Diagnosis));
            Assert.That(result.Prescription, Is.EqualTo(medicalRecord.Prescription));
            Assert.That(result.RecordDate, Is.EqualTo(medicalRecord.RecordDate));
        });
    }

    [Test]
    public async Task DeleteMedicalRecord_DeletesSuccessfully()
    {
        var product = MedicalRecordsTests.CreateMedicalRecords().First();

        _medicalRecordsetupsitoryMock.Setup(setup => setup.CreateMedicalRecord(product)).ReturnsAsync(product);
        _medicalRecordsetupsitoryMock.Setup(setup => setup.DeleteMedicalRecord(product.Id)).Returns(Task.CompletedTask);
        _medicalRecordsetupsitoryMock.Setup(setup => setup.GetMedicalRecordById(product.Id)).ReturnsAsync((MedicalRecords)null);

        await _medicalRecordsService.CreateMedicalRecord(product);
        await _medicalRecordsService.DeleteMedicalRecord(product.Id);

        var exception = Assert.ThrowsAsync<CustomException>(async () => await _medicalRecordsService.GetMedicalRecordById(product.Id));

        Assert.Multiple(() =>
        {
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(exception.Message, Is.EqualTo("Medical record not found."));
        });
    }
}
