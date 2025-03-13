using HealthSync.Infrastructure.Data;
using HealthSync.Infrastructure.Repositories;
using HealthSync.Tests.Templates;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Tests.Repositories;

[TestFixture]
public class MedicalRecordRepositoryTests
{
    private MedicalRecordRepository _medicalRecordRepository;
    private ApplicationDbContext _context;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

        _context = new ApplicationDbContext(options);
        _medicalRecordRepository = new MedicalRecordRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetMedicalRecords_ReturnsMedicalRecords()
    {
        var medicalRecords = MedicalRecordsTests.CreateMedicalRecords();
        _context.MedicalRecords.AddRange(medicalRecords);
        await _context.SaveChangesAsync();

        var result = await _medicalRecordRepository.GetMedicalRecords();

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
        await _medicalRecordRepository.CreateMedicalRecord(medicalRecord);

        var result = await _medicalRecordRepository.GetMedicalRecordById(medicalRecord.Id);

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
    public async Task GetMedicalRecordsByPatientId_ReturnsMedicalRecords()
    {
        var medicalRecords = MedicalRecordsTests.CreateMedicalRecords();
        _context.MedicalRecords.AddRange(medicalRecords);
        await _context.SaveChangesAsync();

        var result = await _medicalRecordRepository.GetMedicalRecordsByPatientId(medicalRecords[0].PatientId);

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
    public async Task CreateMedicalRecord_CreatesSuccessfully()
    {
        var newMedicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();

        var result = await _medicalRecordRepository.CreateMedicalRecord(newMedicalRecord);
        var addedMedicalRecord = await _medicalRecordRepository.GetMedicalRecordById(newMedicalRecord.Id);

        Assert.That(addedMedicalRecord, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(addedMedicalRecord.Id, Is.EqualTo(newMedicalRecord.Id));
            Assert.That(addedMedicalRecord.PatientId, Is.EqualTo(newMedicalRecord.PatientId));
            Assert.That(addedMedicalRecord.DoctorId, Is.EqualTo(newMedicalRecord.DoctorId));
            Assert.That(addedMedicalRecord.Diagnosis, Is.EqualTo(newMedicalRecord.Diagnosis));
            Assert.That(addedMedicalRecord.Prescription, Is.EqualTo(newMedicalRecord.Prescription));
            Assert.That(addedMedicalRecord.RecordDate, Is.EqualTo(newMedicalRecord.RecordDate));
        });
    }

    [Test]
    public async Task UpdateMedicalRecord_UpdatesSuccessfully()
    {
        var existingMedicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();
        await _medicalRecordRepository.CreateMedicalRecord(existingMedicalRecord);

        _context.Entry(existingMedicalRecord).State = EntityState.Detached;

        var updatedAppointment = MedicalRecordsTests.UpdateMedicalRecord(
            existingMedicalRecord.Id, existingMedicalRecord.PatientId, existingMedicalRecord.DoctorId);

        await _medicalRecordRepository.UpdateMedicalRecord(updatedAppointment);
        var retrievedUpdatedMedicalRecord = await _medicalRecordRepository.GetMedicalRecordById(existingMedicalRecord.Id);

        Assert.That(retrievedUpdatedMedicalRecord, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(retrievedUpdatedMedicalRecord.Id, Is.EqualTo(updatedAppointment.Id));
            Assert.That(retrievedUpdatedMedicalRecord.PatientId, Is.EqualTo(updatedAppointment.PatientId));
            Assert.That(retrievedUpdatedMedicalRecord.DoctorId, Is.EqualTo(updatedAppointment.DoctorId));
            Assert.That(retrievedUpdatedMedicalRecord.Diagnosis, Is.EqualTo(updatedAppointment.Diagnosis));
            Assert.That(retrievedUpdatedMedicalRecord.Prescription, Is.EqualTo(updatedAppointment.Prescription));
            Assert.That(retrievedUpdatedMedicalRecord.RecordDate, Is.EqualTo(updatedAppointment.RecordDate));
        });
    }

    [Test]
    public async Task DeleteMedicalRecord_DeletesSuccessfully()
    {
        var existingMedicalRecord = MedicalRecordsTests.CreateMedicalRecords().First();

        await _medicalRecordRepository.CreateMedicalRecord(existingMedicalRecord);
        await _medicalRecordRepository.DeleteMedicalRecord(existingMedicalRecord.Id);
        var retrivedEmptyMedicalRecord = await _medicalRecordRepository.GetMedicalRecordById(existingMedicalRecord.Id);

        Assert.That(retrivedEmptyMedicalRecord, Is.Null);
    }
}
