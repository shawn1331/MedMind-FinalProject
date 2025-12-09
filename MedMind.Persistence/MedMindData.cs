using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedMind.Logic;
namespace MedMind.Persistence;
public class MedMindData
{
    public List<Medication> Medications { get; set; } = new();
    public List<Appointment> Appointments { get; set; } = new();
    //public List<DoseLogEntry> DoseLogs { get; set; } = new();
}
