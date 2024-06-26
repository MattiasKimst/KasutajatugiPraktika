namespace KasutajatugiPraktika.Models;

public class Ticket
{
    public Guid Id { get; } 
    public string Description { get; set; } //set method as user specifies its value
    public DateTime InsertionTime { get; }
    public DateTime Deadline { get; set; } // set method as user specifies its value

    public Ticket(string description, DateTime deadline)
    {
        //user specifies description and deadline, id is generated automatically and insertion time is current time
        Id = Guid.NewGuid();
        Description = description;
        InsertionTime = DateTime.Now;
        Deadline = deadline;
    }
}