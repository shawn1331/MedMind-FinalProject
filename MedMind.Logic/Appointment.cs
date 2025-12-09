public class Appointment
{
    public Guid ID { get; private set; }
    public DateTime AppointmentTime { get; set; }  
    public string ProviderName { get; set; }      
    public string Location { get; set; }           
    public string Purpose { get; set; }             

    public Appointment(DateTime appointmentTime, string providerName, string location, string purpose)
    {
        ID = Guid.NewGuid();
        AppointmentTime = appointmentTime;
        ProviderName = providerName;
        Location = location;
        Purpose = purpose;
    }

    public Appointment(Guid id, DateTime appointmentTime, string providerName, string location, string purpose)
    {
        ID = id;
        AppointmentTime = appointmentTime;
        ProviderName = providerName;
        Location = location;
        Purpose = purpose;
    }

    public override string ToString()
    {
        return $"{AppointmentTime:g} - {ProviderName} @ {Location} ({Purpose})";
    }
}
