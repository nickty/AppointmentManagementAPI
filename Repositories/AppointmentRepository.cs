using System.Collections.Concurrent;

public class AppointmentRepository
{
    private readonly ConcurrentDictionary<int, Appointment> _appointments = new();
    private int _currentId = 0;

    public int Add(Appointment appointment)
    {
        var id = ++_currentId;
        appointment.AppointmentId = id;
        _appointments[id] = appointment;
        return id;
    }

    public List<Appointment> GetAll() => _appointments.Values.ToList();

    public Appointment GetById(int id) => _appointments.TryGetValue(id, out var appointment) ? appointment : null;

    public bool Update(int id, Appointment updatedAppointment)
    {
        if (!_appointments.ContainsKey(id)) return false;
        _appointments[id] = updatedAppointment;
        return true;
    }

    public bool Delete(int id) => _appointments.TryRemove(id, out _);
}
