// Shawn Miner MedMind Final Project Intro. To Software Engineering
using MedMind.Logic;
using System.Globalization;

MedMindService service = new();
bool exit = false;


while (!exit)
{
    PrintMenu();

    int choice = GetMenuOption();
    if (choice == 1)
    {
        Medication med = new(Guid.NewGuid(), GetMedicationName(), GetDosageMg(), GetStartDate(), GetEndDate());
        service.AddMedication(med);
    }
    else if (choice == 2)
    {
        List<Medication> medications = service.GetMedications();
        foreach (var item in medications)
        {
            Console.WriteLine(item);
        }
    }
    else if (choice == 3)
    {
        Appointment appt = new(GetAppointmentTime(), GetProviderName(), GetAppointmentLocation(), GetAppointmentPurpose());
        service.AddAppointment(appt);
    }
    else if (choice == 4)
    {
        var todaysAppts = service.GetAppointmentsForDate(GetTodaysDate());
        foreach (var item in todaysAppts)
        {
            Console.WriteLine(item);
        }
    }
    else if (choice == 5)
    {
        exit = true;
    }
}

Console.WriteLine("Thank you for using MedMind.");

static string PrintMenu() => @"           Welcome to MedMind

   What would you like to do?

1. Add Medication
2. View All Medications
3. Add Appointment
4. View Appointment By Date
5. Exit Program";

static int GetMenuOption() => Console.ReadKey(true).KeyChar;

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
        return GetStartDate();
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
        return GetStartDate();
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