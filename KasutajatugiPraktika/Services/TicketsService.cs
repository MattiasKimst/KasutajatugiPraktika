using KasutajatugiPraktika.Models;

namespace KasutajatugiPraktika.Services;

//as we are not using a db, this class is for in memory storing and manipulation with tickets
public class TicketsService
{
    private static List<Ticket> tickets = new List<Ticket>();
    
    // method that returns a list of all tickets sorted by deadline descending
    public List<Ticket> GetSortedTicketList()
    {
        return tickets.OrderByDescending(p => p.Deadline).ToList();
    }

    //method for adding a new ticket by description and deadline
    public void addNewTicket(string description, DateTime deadline)
    {
        Ticket ticket = new Ticket(description, deadline);
        tickets.Add(ticket);
    }

    //method for deleting a ticket by id
    public void deleteTicket(int id)
    {
        foreach (Ticket ticket in tickets)
        {
            if (ticket.Id==id)
            {
                tickets.Remove(ticket);
            }
        }
    }
}