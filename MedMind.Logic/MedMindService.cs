using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
namespace MedMind.Logic;
public class MedMindService
{
    public List<Medication> Medications { get; }
    public List<Appointment> Appointments { get; }

    public MedMindService()
    {
        Medications = new();
        Appointments = new();
    }

    public void AddMedication(Medication med) => Medications.Add(med);

    public List<Medication> GetMedications() => Medications;

    public void AddAppointment(Appointment appt) => Appointments.Add(appt);

    public List<Appointment> GetAppointmentsForDate(DateTime time) => Appointments.FindAll(a => a.AppointmentTime == time);
}
