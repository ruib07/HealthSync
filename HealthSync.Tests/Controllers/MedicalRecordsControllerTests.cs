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
public class MedicalRecordsControllerTests
{
    private Mock<IMedicalRecordRepository> _medicalRecordRepositoryMock;
    private MedicalRecordsService _medicalRecordsService;
    private MedicalRecordsController _medicalRecordsController;

    [SetUp]
    public void Setup()
    {
        _medicalRecordRepositoryMock = new Mock<IMedicalRecordRepository>();
        _medicalRecordsService = new MedicalRecordsService(_medicalRecordRepositoryMock.Object);
        _medicalRecordsController = new MedicalRecordsController(_medicalRecordsService);
    }

    [Test]
    public async Task GetMedicalRecords_ReturnsOkResult_WithMedicalRecords()
    {
        var medicalRecords = MedicalRecordsTests.CreateMedicalRecords();

        _medicalRecordRepositoryMock.Setup(setup => setup.GetMedicalRecords()).ReturnsAsync(medicalRecords);

        var result = await _medicalRecordsController.GetMedicalRecords();
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as IEnumerable<MedicalRecords>;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Count(), Is.EqualTo(2));
            Assert.That(response.First().Id, Is.EqualTo(medicalRecords[0].Id));
            Assert.That(response.First().PatientId, Is.EqualTo(medicalRecords[0].PatientId));
            Assert.That(response.First().DoctorId, Is.EqualTo(medicalRecords[0].DoctorId));
            Assert.That(response.Last().Id, Is.EqualTo(medicalRecords[1].Id));
            Assert.That(response.Last().PatientId, Is.EqualTo(medicalRecords[1].PatientId));
            Assert.That(response.Last().DoctorId, Is.EqualTo(medicalRecords[1].DoctorId));
        });
    }

    [Test]
    public async Task GetMedicalRecordById_ReturnsOkResult_WithMedicalRecord()
    {
        var medicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();

        _medicalRecordRepositoryMock.Setup(setup => setup.GetMedicalRecordById(medicalRecord.Id)).ReturnsAsync(medicalRecord);

        var result = await _medicalRecordsController.GetMedicalRecordById(medicalRecord.Id);
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as MedicalRecords;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Id, Is.EqualTo(medicalRecord.Id));
            Assert.That(response.PatientId, Is.EqualTo(medicalRecord.PatientId));
            Assert.That(response.DoctorId, Is.EqualTo(medicalRecord.DoctorId));
            Assert.That(response.Diagnosis, Is.EqualTo(medicalRecord.Diagnosis));
            Assert.That(response.Prescription, Is.EqualTo(medicalRecord.Prescription));
            Assert.That(response.RecordDate, Is.EqualTo(medicalRecord.RecordDate));
        });
    }

    [Test]
    public async Task GetMedicalRecordsByPatientId_ReturnsOkResult_WithMedicalRecords()
    {
        var medicalRecords = MedicalRecordsTests.CreateMedicalRecords();
        var singleMedicalRecordList = new List<MedicalRecords>() { medicalRecords[0] };

        _medicalRecordRepositoryMock.Setup(setup => setup.GetMedicalRecordsByPatientId(medicalRecords[0].PatientId)).ReturnsAsync(singleMedicalRecordList);

        var result = await _medicalRecordsController.GetMedicalRecordsByPatientId(medicalRecords[0].PatientId);
        var okResult = result.Result as OkObjectResult;
        var response = okResult.Value as IEnumerable<MedicalRecords>;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(response.Count(), Is.EqualTo(1));
            Assert.That(response.First().Id, Is.EqualTo(medicalRecords[0].Id));
            Assert.That(response.First().PatientId, Is.EqualTo(medicalRecords[0].PatientId));
            Assert.That(response.First().DoctorId, Is.EqualTo(medicalRecords[0].DoctorId));
            Assert.That(response.First().Diagnosis, Is.EqualTo(medicalRecords[0].Diagnosis));
            Assert.That(response.First().Prescription, Is.EqualTo(medicalRecords[0].Prescription));
            Assert.That(response.First().RecordDate, Is.EqualTo(medicalRecords[0].RecordDate));
        });
    }

    [Test]
    public async Task CreateMedicalRecord_ReturnsCreatedResult_WhenMedicalRecordIsCreated()
    {
        var newMedicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();

        _medicalRecordRepositoryMock.Setup(setup => setup.CreateMedicalRecord(newMedicalRecord)).ReturnsAsync(newMedicalRecord);

        var result = await _medicalRecordsController.CreateMedicalRecord(newMedicalRecord);
        var createdResult = result.Result as CreatedAtActionResult;
        var response = createdResult.Value as ResponsesDTO.Creation;

        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(createdResult.StatusCode, Is.EqualTo(201));
            Assert.That(response.Message, Is.EqualTo("Medical record created successfully."));
            Assert.That(response.Id, Is.EqualTo(newMedicalRecord.Id));
        });
    }

    [Test]
    public async Task UpdateMedicalRecord_ReturnsOkResult_WhenMedicalRecordIsUpdated()
    {
        var medicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();
        var updatedMedicalRecord = MedicalRecordsTests.UpdateMedicalRecord(medicalRecord.Id, medicalRecord.PatientId, medicalRecord.DoctorId);

        _medicalRecordRepositoryMock.Setup(setup => setup.GetMedicalRecordById(medicalRecord.Id)).ReturnsAsync(medicalRecord);
        _medicalRecordRepositoryMock.Setup(setup => setup.UpdateMedicalRecord(It.IsAny<MedicalRecords>())).Returns(Task.CompletedTask);

        var result = await _medicalRecordsController.UpdateMedicalRecord(medicalRecord.Id, updatedMedicalRecord);
        var okResult = result.Result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo("Medical record updated successfully."));
        });
    }

    [Test]
    public async Task DeleteMedicalRecord_ReturnsNoContentResult_WhenMedicalRecordIsDeleted()
    {
        var medicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();

        _medicalRecordRepositoryMock.Setup(setup => setup.GetMedicalRecordById(medicalRecord.Id)).ReturnsAsync(medicalRecord);
        _medicalRecordRepositoryMock.Setup(setup => setup.DeleteMedicalRecord(medicalRecord.Id)).Returns(Task.CompletedTask);

        var result = await _medicalRecordsController.DeleteMedicalRecord(medicalRecord.Id);
        var noContentResult = result as NoContentResult;

        Assert.That(noContentResult.StatusCode, Is.EqualTo(204));
    }
}
