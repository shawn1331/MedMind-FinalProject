namespace MedMind.Logic;

public class Medication
{
    public Guid ID { get; private set; }
    public string Name { get; private set; }
    public float DosageMg { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Medication(Guid id, string name, float dosageMg, DateTime startDate, DateTime endDate)
    {
        ID = id;
        Name = name;
        DosageMg = dosageMg;
        StartDate = startDate;
        EndDate = endDate;
    }
}
