namespace KasutajatugiPraktika.Models;

public class Ticket
{
    private static int _idCounter=1; // for giving new id-s we track here which id-s are already used
    
    public int Id { get; } 
    public string Description { get; set; } //set method as user specifies its value
    public DateTime InsertionTime { get; }
    public DateTime Deadline { get; set; } // set method as user specifies its value

    public Ticket(string description, DateTime deadline)
    {
        Id = _idCounter++;
        Description = description;
        InsertionTime = DateTime.Now;
        Deadline = deadline;
    }
}