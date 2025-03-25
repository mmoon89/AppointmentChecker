namespace AppointmentChecker;

public class AppointmentScheduler
{
    public bool CanAttendAllAppointments(List<Appointment> appointments)
    {
        var sortedAppointments = appointments.OrderBy(a => a.StartTime).ToList();

        for (int i = 0; i < sortedAppointments.Count - 1; i++)
        {
            if (sortedAppointments[i].EndTime >= sortedAppointments[i + 1].StartTime)
            {
                return false;
            }
        }
        return true;
    }
}
