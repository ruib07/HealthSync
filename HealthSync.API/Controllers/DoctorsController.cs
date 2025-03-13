using HealthSync.Application.Constants;
using HealthSync.Application.Services;
using HealthSync.Domain.DTOs;
using HealthSync.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthSync.API.Controllers;

[Route($"api/{AppSettings.ApiVersion}/doctors")]
public class DoctorsController : ControllerBase
{
    private readonly DoctorsService _doctorsService;

    public DoctorsController(DoctorsService doctorsService)
    {
        _doctorsService = doctorsService;
    }

    // GET api/v1/doctors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctors>>> GetDoctors()
    {
        var doctors = await _doctorsService.GetDoctors();

        return Ok(doctors);
    }

    // GET api/v1/doctors/{doctorId}
    [HttpGet("{doctorId}")]
    public async Task<ActionResult<Doctors>> GetDoctorById([FromRoute] Guid doctorId)
    {
        var doctor = await _doctorsService.GetDoctorById(doctorId);

        return Ok(doctor);
    }

    // POST api/v1/doctors
    [HttpPost]
    public async Task<ActionResult<Doctors>> CreateDoctor([FromBody] Doctors doctor)
    {
        var createdDoctor = await _doctorsService.CreateDoctor(doctor);

        var response = new ResponsesDTO.Creation("Doctor created successfully.", createdDoctor.Id);

        return CreatedAtAction(nameof(GetDoctorById), new { doctorId = createdDoctor.Id }, response);
    }

    // PUT api/v1/doctors/{doctorId}
    [HttpPut("{doctorId}")]
    public async Task<ActionResult<Doctors>> UpdateDoctor(Guid doctorId, [FromBody] Doctors updateDoctor)
    {
        await _doctorsService.UpdateDoctor(doctorId, updateDoctor);

        return Ok("Doctor updated successfully.");
    }

    // DELETE api/v1/doctors/{doctorId}
    [HttpDelete("{doctorId}")]
    public async Task<IActionResult> DeleteDoctor(Guid doctorId)
    {
        await _doctorsService.DeleteDoctor(doctorId);

        return NoContent();
    }
}
