using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedMind.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MedMindService
{
    public List<Medication> Medications { get; }
    public List<Appointment> Appointments { get; }
    //public List<DoseLogEntry> DoseLogs { get; }

    public MedMindService(List<Medication> meds, List<Appointment> appts)
        { 
        Medications = meds;
        Appointments = appts;
    }

    public void AddMedication(Medication med) => Medications.Add(med);

    public List<Medication> GetMedications() => Medications;

    public bool EditMedication(Medication medication)
    {
        int index = Medications.FindIndex(m => m.ID == medication.ID);
        if (index != -1)
        {
            Medications[index].Name = medication.Name;
            Medications[index].DosageMg = medication.DosageMg;
            Medications[index].StartDate = medication.StartDate;
            Medications[index].EndDate = medication.EndDate;
            return true;
        }
        return false;
    }

    public void AddAppointment(Appointment appt) => Appointments.Add(appt);

    public List<Appointment> GetAppointments() => Appointments;

    public List<Appointment> GetAppointmentsForDate(DateTime date) =>
        Appointments.FindAll(a => a.AppointmentTime.Date == date.Date);

    public bool EditAppointment(Appointment updatedAppointment)
    {
        int index = Appointments.FindIndex(a => a.ID == updatedAppointment.ID);
        if (index == -1)
        {
            return false;
        }

        Appointments[index].AppointmentTime = updatedAppointment.AppointmentTime;
        Appointments[index].ProviderName = updatedAppointment.ProviderName;
        Appointments[index].Location = updatedAppointment.Location;
        Appointments[index].Purpose = updatedAppointment.Purpose;

        return true;
    }
}
