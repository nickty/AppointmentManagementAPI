public class AppointmentRepository
{
    private readonly List<Appointment> _appointments = new List<Appointment>();

    // Add Appointment
    public int Add(Appointment appointment)
    {
        appointment.AppointmentId = _appointments.Count + 1; // Generate unique ID for Appointment
        _appointments.Add(appointment);
        return appointment.AppointmentId;
    }

    // Get All Appointments
    public List<Appointment> GetAll()
    {
        return _appointments;
    }

    // Get Appointment by ID
    public Appointment GetById(int id)
    {
        return _appointments.FirstOrDefault(a => a.AppointmentId == id);
    }

    // Update Appointment
    public bool Update(int id, Appointment updatedAppointment)
    {
        var existingAppointment = GetById(id);
        if (existingAppointment == null)
        {
            return false; // Appointment not found
        }

        // Update existing appointment details
        existingAppointment.PatientName = updatedAppointment.PatientName;
        existingAppointment.PatientContact = updatedAppointment.PatientContact;
        existingAppointment.AppointmentDateTime = updatedAppointment.AppointmentDateTime;
        existingAppointment.DoctorId = updatedAppointment.DoctorId;
        existingAppointment.Doctor = updatedAppointment.Doctor;

        return true;
    }

    // Delete Appointment
    public bool Delete(int id)
    {
        var appointment = GetById(id);
        if (appointment == null)
        {
            return false; // Appointment not found
        }

        _appointments.Remove(appointment);
        return true;
    }
}
