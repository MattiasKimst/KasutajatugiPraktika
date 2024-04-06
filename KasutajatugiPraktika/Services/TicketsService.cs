using KasutajatugiPraktika.Models;

namespace KasutajatugiPraktika.Services;

//as we are not using a db, this class is for in memory storing and manipulation with tickets
public class TicketsService
{
    private readonly ILogger<TicketsService> _logger;
    
    private static List<Ticket> tickets = new List<Ticket>();
    
    // method that returns a list of all tickets sorted by deadline descending
    public static List<Ticket> GetSortedTicketList()
    {
        List<Ticket> sortedTickets=tickets.OrderByDescending(p => p.Deadline).ToList();
        return sortedTickets;
    }

    //method for adding a new ticket by description and deadline
    public static void addNewTicket(string description, DateTime deadline)
    {
        Ticket ticket = new Ticket(description, deadline);
        tickets.Add(ticket);
    }

    //method for deleting a ticket by id
    public static void deleteTicket(int id)
    {
        Ticket removableTicket=null;
        
        foreach (Ticket ticket in tickets)
        {
            if (ticket.Id==id)
            {
                removableTicket = ticket;
            }
        }

        if (removableTicket!=null)
        {
            tickets.Remove(removableTicket);
        }
        
    }
}