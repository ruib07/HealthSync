using HealthSync.Application.Constants;
using HealthSync.Application.Services;
using HealthSync.Domain.DTOs;
using HealthSync.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthSync.API.Controllers;

[Route($"api/{AppSettings.ApiVersion}/appointments")]
public class AppointmentsController : ControllerBase
{
    private readonly AppointmentsService _appointmentsService;

    public AppointmentsController(AppointmentsService appointmentsService)
    {
        _appointmentsService = appointmentsService;
    }

    // GET api/v1/appointments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointments>>> GetAppointments()
    {
        var appointments = await _appointmentsService.GetAppointments();

        return Ok(appointments);
    }

    // GET api/v1/appointments/{appointmentId}
    [HttpGet("{appointmentId}")]
    public async Task<ActionResult<Appointments>> GetAppointmentById([FromRoute] Guid appointmentId)
    {
        var appointment = await _appointmentsService.GetAppointmentById(appointmentId);

        return Ok(appointment);
    }

    // GET api/v1/appointments/bypatient/{patientId}
    [HttpGet("bypatient/{patientId}")]
    public async Task<ActionResult<IEnumerable<Appointments>>> GetAppointmentsByPatientId([FromRoute] Guid patientId)
    {
        var appointment = await _appointmentsService.GetAppointmentsByPatientId(patientId);

        return Ok(appointment);
    }

    // GET api/v1/appointments/bydoctor/{doctorId}
    [HttpGet("bydoctor/{doctorId}")]
    public async Task<ActionResult<IEnumerable<Appointments>>> GetAppointmentsByDoctorId([FromRoute] Guid doctorId)
    {
        var appointment = await _appointmentsService.GetAppointmentsByDoctorId(doctorId);

        return Ok(appointment);
    }

    // POST api/v1/appointments
    [HttpPost]
    public async Task<ActionResult<Appointments>> CreateAppointment([FromBody] Appointments appointment)
    {
        var createdAppointment = await _appointmentsService.CreateAppointment(appointment);

        var response = new ResponsesDTO.Creation("Appointment created successfully.", createdAppointment.Id);

        return CreatedAtAction(nameof(GetAppointmentById), new { appointmentId = createdAppointment.Id }, response); 
    }

    // PUT api/v1/appointments/{appointmentId}
    [HttpPut("{appointmentId}")]
    public async Task<ActionResult<Appointments>> UpdateAppointment(Guid appointmentId, [FromBody] Appointments updateAppointment)
    {
        await _appointmentsService.UpdateAppointment(appointmentId, updateAppointment);

        return Ok("Appointment updated successfully.");
    }

    // DELETE api/v1/appointments/{appointmentId}
    [HttpDelete("{appointmentId}")]
    public async Task<IActionResult> DeleteAppointment(Guid appointmentId)
    {
        await _appointmentsService.DeleteAppointment(appointmentId);

        return NoContent();
    }
}
