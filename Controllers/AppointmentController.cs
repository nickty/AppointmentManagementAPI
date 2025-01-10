using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


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

    [HttpPost]
    public IActionResult Create(Appointment appointment)
    {
        var id = _appointmentRepository.Add(appointment);
        return CreatedAtAction(nameof(GetById), new { id }, appointment);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_appointmentRepository.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var appointment = _appointmentRepository.GetById(id);
        if (appointment == null) return NotFound();
        return Ok(appointment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Appointment updatedAppointment)
    {
        if (!_appointmentRepository.Update(id, updatedAppointment)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_appointmentRepository.Delete(id)) return NotFound();
        return NoContent();
    }
}
