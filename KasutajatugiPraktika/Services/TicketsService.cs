using KasutajatugiPraktika.Models;

namespace KasutajatugiPraktika.Services;

public interface TicketsService
{
    List<Ticket> GetSortedTicketList();
    void AddNewTicket(string description, DateTime deadline);
    void DeleteTicket(int id);
}