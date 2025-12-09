namespace MedMind.Logic;

public class Medication
{
    public Guid ID { get; private set; }
    public string Name { get; set; }          
    public float DosageMg { get; set; }      
    public DateTime StartDate { get; set; }    
    public DateTime EndDate { get; set; }     

    public Medication(Guid id, string name, float dosageMg, DateTime startDate, DateTime endDate)
    {
        ID = id;
        Name = name;
        DosageMg = dosageMg;
        StartDate = startDate;
        EndDate = endDate;
    }

    public override string ToString()
    {
        return $"{Name} ({DosageMg} mg) {StartDate:d} - {EndDate:d}";
    }
}
