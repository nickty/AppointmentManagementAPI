using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentRepository _appointmentRepository;

    public AppointmentController(AppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    // Create Appointment
    [HttpPost]
    public IActionResult Create([FromBody] Appointment appointment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Return validation errors
        }

        var id = _appointmentRepository.Add(appointment);
        return CreatedAtAction(nameof(GetById), new { id }, appointment);
    }

    // Get All Appointments
    [HttpGet]
    public IActionResult GetAll()
    {
        var appointments = _appointmentRepository.GetAll();
        return Ok(appointments);
    }

    // Get Appointment by ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var appointment = _appointmentRepository.GetById(id);
        if (appointment == null)
        {
            return NotFound(); // Appointment not found
        }
        return Ok(appointment);
    }

    // Update Appointment
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Appointment updatedAppointment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!_appointmentRepository.Update(id, updatedAppointment))
        {
            return NotFound(); // Appointment not found
        }

        return NoContent(); // Successfully updated
    }

    // Delete Appointment
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_appointmentRepository.Delete(id))
        {
            return NotFound(); // Appointment not found
        }

        return NoContent(); // Successfully deleted
    }
}
