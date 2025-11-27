namespace MedMind.Tests;
using MedMind.Logic;
using FluentAssertions;

public class MedMindServiceTests
{
    private Medication SetUpMedication()
    {
        return new(Guid.NewGuid(), "Aspirin", 500.0f, new DateTime(2025, 12, 1), new DateTime(2026, 6, 1));
    }

    private Appointment SetUpAppointment()
    {
        return new(new DateTime(2025, 12, 1, 15, 30, 0), "Dr. Matthews", "Provo Office", "Medication Refills");
    }

    [Fact]
    public void TestMedicationsPropertiesArentNull()
    {
        var med = SetUpMedication();
        med.StartDate.Should().Be(new DateTime(2025,12,1));
        med.EndDate.Should().Be(new DateTime(2026,6,1));
        med.Name.Should().Be("Aspirin");
        med.DosageMg.Should().Be(500.0f);
        med.ID.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void TestAppointmentPropertiesArentNull()
    {
        var appt = SetUpAppointment();
        appt.AppointmentTime.Should().Be(new DateTime(2025,12,1,15,30,0));
        appt.ProviderName.Should().Be("Dr. Matthews");
        appt.Location.Should().Be("Provo Office");
        appt.Purpose.Should().Be("Medication Refills");
    }

    [Fact]
    public void TestAddMedication()
    {
        MedMindService service = new();
        var med = SetUpMedication();
        service.AddMedication(med);
        service.Medications.Should().HaveCount(1);
        service.Medications.Contains(med).Should().BeTrue();
    }

    [Fact]
    public void TestAddAppointment()
    {
        MedMindService service = new();
        var appt = SetUpAppointment();
        service.AddAppointment(appt);
        service.Appointments.Should().HaveCount(1);
        service.Appointments.Contains(appt).Should().BeTrue();
    }

    [Fact]
    public void TestGetAllMedications()
    {
        MedMindService service = new();
        var med1 = SetUpMedication();
        var med2 = new Medication(Guid.NewGuid(), "Ibuprofen", 200.0f, new DateTime(2025, 11, 1), new DateTime(2026, 5, 1));
        service.AddMedication(med1);
        service.AddMedication(med2);
        var meds = service.GetMedications();
        meds.Should().HaveCount(2);
        meds.Should().Equal(new List<Medication> { med1, med2 });
    }

    [Fact]
    public void TestGetAppointmentByDate()
    {
        MedMindService service = new();
        var appt1 = SetUpAppointment();
        var app2 = new Appointment(new DateTime(2025, 6, 20), "Dr. Stevens", "Mt. Pleasant Office", "Antiboitics");
        service.AddAppointment(appt1);
        service.AddAppointment(app2);
        var todaysAppt = service.GetAppointmentsForDate(new DateTime(2025, 6, 20));
        todaysAppt.Should().Contain(app2);
        todaysAppt.Should().HaveCount(1);
    }
}
