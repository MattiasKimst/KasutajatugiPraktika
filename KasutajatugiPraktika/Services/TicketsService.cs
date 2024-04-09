using KasutajatugiPraktika.Models;

namespace KasutajatugiPraktika.Services;

public interface TicketsService
{
    List<Ticket> GetSortedTicketList();
    Guid AddNewTicket(string description, DateTime deadline);
    void DeleteTicket(Guid id);
}