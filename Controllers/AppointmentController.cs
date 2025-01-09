[ApiController]
[Route("[controller]")]
[Authorize]
public class AppointmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public AppointmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = appointment.AppointmentId }, appointment);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Appointments.Include(a => a.Doctor).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var appointment = _context.Appointments.Include(a => a.Doctor).SingleOrDefault(a => a.AppointmentId == id);
        if (appointment == null) return NotFound();
        return Ok(appointment);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Appointment updatedAppointment)
    {
        var appointment = _context.Appointments.Find(id);
        if (appointment == null) return NotFound();

        appointment.PatientName = updatedAppointment.PatientName;
        appointment.PatientContact = updatedAppointment.PatientContact;
        appointment.AppointmentDateTime = updatedAppointment.AppointmentDateTime;
        appointment.DoctorId = updatedAppointment.DoctorId;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var appointment = _context.Appointments.Find(id);
        if (appointment == null) return NotFound();

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
        return NoContent();
    }
}
