public class Appointment
{
    public int AppointmentId { get; set; }
    public string PatientName { get; set; }
    public string PatientContact { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}
