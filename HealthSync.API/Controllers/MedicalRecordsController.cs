using HealthSync.Application.Constants;
using HealthSync.Application.Services;
using HealthSync.Domain.DTOs;
using HealthSync.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthSync.API.Controllers;

[Route($"api/{AppSettings.ApiVersion}/medicalrecords")]
public class MedicalRecordsController : ControllerBase
{
    private readonly MedicalRecordsService _medicalRecordsService;

    public MedicalRecordsController(MedicalRecordsService medicalRecordsService)
    {
        _medicalRecordsService = medicalRecordsService;
    }

    // GET api/v1/medicalrecords
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicalRecords>>> GetMedicalRecords()
    {
        var medicalRecords = await _medicalRecordsService.GetMedicalRecords();

        return Ok(medicalRecords);
    }

    // GET api/v1/medicalrecords/{medicalRecordId}
    [HttpGet("{medicalRecordId}")]
    public async Task<ActionResult<MedicalRecords>> GetMedicalRecordById([FromRoute] Guid medicalRecordId)
    {
        var medicalRecord = await _medicalRecordsService.GetMedicalRecordById(medicalRecordId);

        return Ok(medicalRecord);
    }

    // GET api/v1/medicalrecords/bypatient/{patientId}
    [HttpGet("bypatient/{patientId}")]
    public async Task<ActionResult<IEnumerable<MedicalRecords>>> GetMedicalRecordsByPatientId([FromRoute] Guid patientId)
    {
        var medicalRecord = await _medicalRecordsService.GetMedicalRecordsByPatientId(patientId);

        return Ok(medicalRecord);
    }

    // POST api/v1/medicalrecords
    [HttpPost]
    public async Task<ActionResult<MedicalRecords>> CreateMedicalRecord([FromBody] MedicalRecords medicalRecord)
    {
        var createdMedicalRecord = await _medicalRecordsService.CreateMedicalRecord(medicalRecord);

        var response = new ResponsesDTO.Creation("Medical record created successfully.", createdMedicalRecord.Id);

        return CreatedAtAction(nameof(GetMedicalRecordById), new { medicalRecordId = createdMedicalRecord.Id }, response); 
    }

    // PUT api/v1/medicalrecords/{medicalRecordId}
    [HttpPut("{medicalRecordId}")]
    public async Task<ActionResult<MedicalRecords>> UpdateMedicalRecord(Guid medicalRecordId, [FromBody] MedicalRecords updateMedicalRecord)
    {
        await _medicalRecordsService.UpdateMedicalRecord(medicalRecordId, updateMedicalRecord);

        return Ok("Medical record updated successfully.");
    }

    // DELETE api/v1/medicalrecords/{medicalRecordId}
    [HttpDelete("{medicalRecordId}")]
    public async Task<IActionResult> DeleteMedicalRecord(Guid medicalRecordId)
    {
        await _medicalRecordsService.DeleteMedicalRecord(medicalRecordId);

        return NoContent();
    }
}
