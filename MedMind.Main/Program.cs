// Shawn Miner MedMind Final Project Intro. To Software Engineering
using MedMind.Logic;
using MedMind.Persistence;
using System.Globalization;
using System.IO;

bool isRunning = true;
var baseDirectory = AppContext.BaseDirectory;
var dataDir = Path.Combine(baseDirectory, "Data");
Directory.CreateDirectory(dataDir);
var dataFilePath = Path.Combine(dataDir, "medmind-data.json");

var repo = new MedMindRepo(dataFilePath);
var data = repo.LoadData();
MedMindService service = new(data.Medications, data.Appointments);

while (isRunning)
{
    Console.Clear();
    PrintMenu();

    char choice = GetMenuOption();
    if (choice == '1')
    {
        Medication med = new(Guid.NewGuid(), GetMedicationName(), GetDosageMg(), GetStartDate(), GetEndDate());
        service.AddMedication(med);
    }
    else if (choice == '2')
    {
        List<Medication> medications = service.GetMedications();
        foreach (var item in medications)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    else if (choice == '3')
    {
        Appointment appt = new(GetAppointmentTime(), GetProviderName(), GetAppointmentLocation(), GetAppointmentPurpose());
        service.AddAppointment(appt);
    }
    else if (choice == '4')
    {
        var todaysAppts = service.GetAppointmentsForDate(GetTodaysDate());
        foreach (var item in todaysAppts)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    else if (choice == '5')
    {
        isRunning = false;
        var finalData = new MedMindData
        {
            Medications = service.Medications,
            Appointments = service.Appointments,
            //DoseLogs = service.DoseLogs
        };
        repo.SaveData(finalData);
    }
    else if (choice == '6')
    {
        EditMedicationFlow(service);
    }
    else if (choice == '7')
    {
        EditAppointmentFlow(service);
    }
}


Console.WriteLine("Thank you for using MedMind.");



static void PrintMenu()
{
    Console.WriteLine(@"           Welcome to MedMind

   What would you like to do?

1. Add Medication
2. View All Medications
3. Add Appointment
4. View Appointment By Date
5. Edit Medication
6. Edit Appointment
7. Exit Program");
}

static char GetMenuOption() => Console.ReadKey(true).KeyChar;

static string GetMedicationName()
{
    Console.Write("Enter the name of the medication: ");
    return Console.ReadLine();
}

static float GetDosageMg()
{
    Console.Write("Enter the dosage of the medication in mg: ");
    if (!float.TryParse(Console.ReadLine(), out float dosage))
    {
        Console.WriteLine("That was an invalid entry. Try again.");
        return GetDosageMg();
    }
    else
        return dosage;
}

static DateTime GetStartDate()
{
    Console.WriteLine("Please Enter the Starting date of the medication in month/day/year format.");
    if (!DateTime.TryParse(Console.ReadLine(), new CultureInfo("en-US"), out DateTime startDate))
    {
        Console.WriteLine("That was invalid entry try again.");
        return GetStartDate();
    }
    else
        return startDate;

}

static DateTime GetEndDate()
{
    Console.WriteLine("Please Enter the Ending date of the medication in month/day/year format.");
    if (!DateTime.TryParse(Console.ReadLine(), new CultureInfo("en-US"), out DateTime endDate))
    {
        Console.WriteLine("That was invalid entry try again.");
        return GetEndDate();
    }
    else
        return endDate;
}

static string GetProviderName()
{
    Console.Write("Please enter the providers name: ");
    return Console.ReadLine();
}

static string GetAppointmentLocation()
{
    Console.Write("Please enter the location of the appointment. For example \"Provo office\".");
    return Console.ReadLine();
}

static string GetAppointmentPurpose()
{
    Console.Write("Please enter the reason for the appointment: ");
    return Console.ReadLine();
}

static DateTime GetAppointmentTime()
{
    Console.WriteLine("Please Enter the Appointment time in month/day/year format.");
    if (!DateTime.TryParse(Console.ReadLine(), new CultureInfo("en-US"), out DateTime appointmentTime))
    {
        Console.WriteLine("That was invalid entry try again.");
        return GetAppointmentTime();
    }
    else
        return appointmentTime;
}

static DateTime GetTodaysDate()
{
    Console.WriteLine("Please Enter todays date in month/day/year format.");
    if (!DateTime.TryParse(Console.ReadLine(), new CultureInfo("en-US"), out DateTime todaysDate))
    {
        Console.WriteLine("That was invalid entry try again.");
        return GetStartDate();
    }
    else
        return todaysDate;
}

static void EditMedicationFlow(MedMindService service)
{
    Console.Clear();
    Console.WriteLine("=== Edit Medication ===");

    var meds = service.GetMedications();
    if (meds.Count == 0)
    {
        Console.WriteLine("There are no medications to edit.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        return;
    }

    for (int i = 0; i < meds.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {meds[i]}");
    }

    Console.Write("Enter the number of the medication you want to edit: ");
    if (!int.TryParse(Console.ReadLine(), out int selection) ||
        selection < 1 || selection > meds.Count)
    {
        Console.WriteLine("Invalid selection. Press Enter to continue...");
        Console.ReadLine();
        return;
    }

    var medToEdit = meds[selection - 1];

    Console.WriteLine($"Editing medication: {medToEdit.Name}");

    string newName = GetMedicationName();
    float newDosage = GetDosageMg();
    DateTime newStart = GetStartDate();
    DateTime newEnd = GetEndDate();

    var updatedMedication = new Medication(
        medToEdit.ID,  
        newName,
        newDosage,
        newStart,
        newEnd);

    bool success = service.EditMedication(updatedMedication);

    if (success)
    {
        Console.WriteLine("Medication updated successfully.");
    }
    else
    {
        Console.WriteLine("Error: medication could not be updated.");
    }

    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

static void EditAppointmentFlow(MedMindService service)
{
    Console.Clear();
    Console.WriteLine("=== Edit Appointment ===");

    var appts = service.GetAppointments();
    if (appts.Count == 0)
    {
        Console.WriteLine("There are no appointments to edit.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        return;
    }

    for (int i = 0; i < appts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {appts[i]}");
    }

    Console.Write("Enter the number of the appointment you want to edit: ");
    if (!int.TryParse(Console.ReadLine(), out int selection) ||
        selection < 1 || selection > appts.Count)
    {
        Console.WriteLine("Invalid selection. Press Enter to continue...");
        Console.ReadLine();
        return;
    }

    var apptToEdit = appts[selection - 1];

    Console.WriteLine($"Editing appointment with {apptToEdit.ProviderName} on {apptToEdit.AppointmentTime:d}");

    DateTime newTime = GetAppointmentTime();
    string newProvider = GetProviderName();
    string newLocation = GetAppointmentLocation();
    string newPurpose = GetAppointmentPurpose();

    var updatedAppointment = new Appointment(
        apptToEdit.ID,   // keep same ID
        newTime,
        newProvider,
        newLocation,
        newPurpose);

    bool success = service.EditAppointment(updatedAppointment);

    if (success)
    {
        Console.WriteLine("Appointment updated successfully.");
    }
    else
    {
        Console.WriteLine("Error: appointment could not be updated.");
    }

    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

