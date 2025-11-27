using System;

public class Appointment
{
    public Guid ID { get; private set; }
    public DateTime AppointmentTime { get; private set; }
    public string ProviderName { get; private set; }
    public string Location { get; private set; }
    public string Purpose { get; private set; }

    public Appointment(DateTime appointmentTime, string providerName, string location, string purpose)
    {
        ID = Guid.NewGuid();
        AppointmentTime = appointmentTime;
        ProviderName = providerName;
        Location = location;
        Purpose = purpose;
    }
}
