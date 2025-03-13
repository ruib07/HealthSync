using HealthSync.Application.Constants;
using HealthSync.Application.Services;
using HealthSync.Domain.DTOs;
using HealthSync.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthSync.API.Controllers;

[Route($"api/{AppSettings.ApiVersion}/patients")]
public class PatientsController : ControllerBase
{
    private readonly PatientsService _patientsService;

    public PatientsController(PatientsService patientsService)
    {
        _patientsService = patientsService;
    }

    // GET api/v1/patients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patients>>> GetPatients()
    {
        var patients = await _patientsService.GetPatients();

        return Ok(patients);
    }

    // GET api/v1/patients/{patientId}
    [HttpGet("{patientId}")]
    public async Task<ActionResult<Patients>> GetPatientById([FromRoute] Guid patientId)
    {
        var patient = await _patientsService.GetPatientById(patientId);

        return Ok(patient);
    }

    // POST api/v1/patients
    [HttpPost]
    public async Task<ActionResult<Patients>> CreatePatient([FromBody] Patients patient)
    {
        var createdPatient = await _patientsService.CreatePatient(patient);

        var response = new ResponsesDTO.Creation("Patient created successfully.", createdPatient.Id);

        return CreatedAtAction(nameof(GetPatientById), new { patientId = createdPatient.Id }, response); 
    }

    // PUT api/v1/patients/{patientId}
    [HttpPut("{patientId}")]
    public async Task<ActionResult<Patients>> UpdatePatient(Guid patientId, [FromBody] Patients updatePatient)
    {
        await _patientsService.UpdatePatient(patientId, updatePatient);

        return Ok("Patient updated successfully.");
    }

    // DELETE api/v1/patients/{patientId}
    [HttpDelete("{patientId}")]
    public async Task<IActionResult> DeletePatient(Guid patientId)
    {
        await _patientsService.DeletePatient(patientId);

        return NoContent();
    }
}
