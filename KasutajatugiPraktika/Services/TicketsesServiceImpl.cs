using KasutajatugiPraktika.Models;

namespace KasutajatugiPraktika.Services;

//as we are not using a db, this class is for in memory storing and manipulation with tickets
public class TicketsesServiceImpl : TicketsService
{
    private readonly ILogger<TicketsesServiceImpl> _logger;

    private static SortedSet<Ticket> tickets =
        new SortedSet<Ticket>(Comparer<Ticket>.Create((x, y) => y.Deadline.CompareTo(x.Deadline)));

    public TicketsesServiceImpl(ILogger<TicketsesServiceImpl> logger)
    {
        _logger = logger;
    }

    // method that returns a list of all tickets sorted by deadline descending
    public List<Ticket> GetSortedTicketList()
    {
        _logger.LogInformation("Tickets sorted successfully.");
        return tickets.ToList();
    }


    //method for adding a new ticket by description and deadline
    public Guid AddNewTicket(string description, DateTime deadline)
    {
        try
        {
            Ticket ticket = new Ticket(description, deadline);
            tickets.Add(ticket);
            _logger.LogInformation("New ticket added successfully with description: " + description +
                                   " and deadline: " + deadline);
            //for testing, we return the id of created ticket so that we can use it later to find the ticket
            return ticket.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "An error occurred while adding a new ticket with description: " + description + " and deadline: " +
                deadline + " The ticket was NOT ADDED");
            return Guid.Empty;
        }
    }

    //method for deleting a ticket by id
    public void DeleteTicket(Guid id)
    {
        try
        {
            Ticket removableTicket = tickets.FirstOrDefault(ticket => ticket.Id == id);
            tickets.Remove(removableTicket);
            _logger.LogInformation("Ticket with ID " + id + " deleted successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "An error occurred while deleting a ticket with ID " + id + "The ticket WAS NOT DELETED");
        }
    }

    
}