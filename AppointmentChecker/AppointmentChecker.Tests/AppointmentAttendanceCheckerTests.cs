using Xunit;

namespace AppointmentChecker.Tests;

public class AppointmentSchedulerTests
{
    private readonly AppointmentScheduler _scheduler = new AppointmentScheduler();

    [Fact]
    public void CanAttendAllAppointments_EmptyList_ReturnsTrue()
    {
        var appointments = new List<Appointment>();

        var result = _scheduler.CanAttendAllAppointments(appointments);

        Assert.True(result);
    }

    [Fact]
    public void CanAttendAllAppointments_SingleAppointment_ReturnsTrue()
    {
        var appointments = new List<Appointment>
        {
            new Appointment { StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) }
        };

        var result = _scheduler.CanAttendAllAppointments(appointments);

        Assert.True(result);
    }

    [Fact]
    public void CanAttendAllAppointments_NoOverlap_ReturnsTrue()
    {
        var appointments = new List<Appointment>
        {
            new Appointment { StartTime = DateTime.Today.AddHours(9), EndTime = DateTime.Today.AddHours(10) },
            new Appointment { StartTime = DateTime.Today.AddHours(10.15), EndTime = DateTime.Today.AddHours(11.15) },
            new Appointment { StartTime = DateTime.Today.AddHours(11.30), EndTime = DateTime.Today.AddHours(12) }
        };

        var result = _scheduler.CanAttendAllAppointments(appointments);

        Assert.True(result);
    }

    [Fact]
    public void CanAttendAllAppointments_Overlap_ReturnsFalse()
    {
        var appointments = new List<Appointment>
        {
            new Appointment { StartTime = DateTime.Today.AddHours(9), EndTime = DateTime.Today.AddHours(10) },
            new Appointment { StartTime = DateTime.Today.AddHours(9.5), EndTime = DateTime.Today.AddHours(10.5) }
        };

        var result = _scheduler.CanAttendAllAppointments(appointments);

        Assert.False(result);
    }

    [Fact]
    public void CanAttendAllAppointments_TouchingAppointments_ReturnsFalse()
    {
        var appointments = new List<Appointment>
        {
            new Appointment { StartTime = DateTime.Today.AddHours(9), EndTime = DateTime.Today.AddHours(10) },
            new Appointment { StartTime = DateTime.Today.AddHours(10), EndTime = DateTime.Today.AddHours(11) }
        };

        var result = _scheduler.CanAttendAllAppointments(appointments);

        Assert.False(result);
    }

    [Fact]
    public void CanAttendAllAppointments_UnsortedInput_ReturnsCorrectResult()
    {
        var appointments = new List<Appointment>
        {
            new Appointment { StartTime = DateTime.Today.AddHours(11.30), EndTime = DateTime.Today.AddHours(12) },
            new Appointment { StartTime = DateTime.Today.AddHours(9), EndTime = DateTime.Today.AddHours(10) },
            new Appointment { StartTime = DateTime.Today.AddHours(10.15), EndTime = DateTime.Today.AddHours(11.15) }
        };

        var result = _scheduler.CanAttendAllAppointments(appointments);

        Assert.True(result);
    }
}
