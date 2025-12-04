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
    public List<DoseLogEntry> DoseLogs { get; }

    public MedMindService(List<Medication> meds, List<Appointment> appts, List<DoseLogEntry> logs)
    {
        Medications = meds;
        Appointments = appts;
        DoseLogs = logs;
    }

    public void AddMedication(Medication med) => Medications.Add(med);

    public List<Medication> GetMedications() => Medications;

    public void AddAppointment(Appointment appt) => Appointments.Add(appt);

    public List<Appointment> GetAppointmentsForDate(DateTime time) => Appointments.FindAll(a => a.AppointmentTime == time);
}
