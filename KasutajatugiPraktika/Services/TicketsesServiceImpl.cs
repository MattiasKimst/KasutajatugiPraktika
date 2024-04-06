using KasutajatugiPraktika.Models;

namespace KasutajatugiPraktika.Services;

//as we are not using a db, this class is for in memory storing and manipulation with tickets
public class TicketsesServiceImpl : TicketsService
{
    private readonly ILogger<TicketsesServiceImpl> _logger;

    private static List<Ticket> tickets = new List<Ticket>();
    
    public TicketsesServiceImpl(ILogger<TicketsesServiceImpl> logger)
    {
        _logger = logger;
    }

    // method that returns a list of all tickets sorted by deadline descending
    public List<Ticket> GetSortedTicketList()
    {
        try
        {
            List<Ticket> sortedTickets = tickets.OrderByDescending(p => p.Deadline).ToList();
            _logger.LogInformation("Tickets sorted successfully.");
            return sortedTickets;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to sort tickets. Returned original list instead");
            return tickets;
        }
    }

    //method for adding a new ticket by description and deadline
    public void AddNewTicket(string description, DateTime deadline)
    {
        try
        {
            Ticket ticket = new Ticket(description, deadline);
            tickets.Add(ticket);
            _logger.LogInformation("New ticket added successfully with description: " + description +
                                   " and deadline: " + deadline);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "An error occurred while adding a new ticket with description: " + description + " and deadline: " +
                deadline + " The ticket was NOT ADDED");
        }
    }

    //method for deleting a ticket by id
    public void DeleteTicket(Guid id)
    {
        try
        {
            Ticket removableTicket = null;

            //find the ticket by id
            foreach (Ticket ticket in tickets)
            {
                if (ticket.Id == id)
                {
                    removableTicket = ticket;
                    break; // no need to continue searching once found
                }
            }

            if (removableTicket != null)
            {
                tickets.Remove(removableTicket);
                _logger.LogInformation("Ticket with ID " + id + " deleted successfully.");
            }
            else
            {
                _logger.LogWarning("Ticket with ID " + id + " not found. Unable to delete.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "An error occurred while deleting a ticket with ID " + id + "The ticket WAS NOT DELETED");
        }
    }
}