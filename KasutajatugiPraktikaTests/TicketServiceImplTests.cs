using Moq;
using KasutajatugiPraktika.Services;
using Microsoft.Extensions.Logging;

namespace KasutajatugiPraktikaTests
{
    public class TicketServiceImplTests
    {
        [Fact]
        public void GetSortedTicketList_ReturnsSortedTickets()
        {
            //create isolated instance of ticket service impl
            var loggerMock = new Mock<ILogger<TicketsesServiceImpl>>();
            var service = new TicketsesServiceImpl(loggerMock.Object);

            // Add sample tickets
            service.AddNewTicket("Ticket 1", DateTime.Now.AddDays(2));
            service.AddNewTicket("Ticket 2", DateTime.Now.AddDays(1));
            service.AddNewTicket("Ticket 3", DateTime.Now.AddDays(3));

            // get the sorted ticket list
            var sortedTickets = service.GetSortedTicketList();

            // Assert the tickets are in correct order in list
            Assert.Equal("Ticket 3", sortedTickets[0].Description);
            Assert.Equal("Ticket 1", sortedTickets[1].Description);
            Assert.Equal("Ticket 2", sortedTickets[2].Description);
            
            
        }

        [Fact]
        public void AddNewTicket_AddsTicketSuccessfully()
        {
            //create isolated instance of ticket service impl
            var loggerMock = new Mock<ILogger<TicketsesServiceImpl>>();
            var service = new TicketsesServiceImpl(loggerMock.Object);

            // add a new ticket
            service.AddNewTicket("New Ticket", DateTime.Now.AddDays(1));

            // after adding ticket there should be only one instance in ticket list and its description should be same as we used for adding
            var sortedTickets = service.GetSortedTicketList();
            Assert.Single(sortedTickets);
            Assert.Equal("New Ticket", sortedTickets[0].Description);
        }

        [Fact]
        public void DeleteTicket_RemovesTicketSuccessfully()
        {
            //create isolated instance of ticket service impl
            var loggerMock = new Mock<ILogger<TicketsesServiceImpl>>();
            var service = new TicketsesServiceImpl(loggerMock.Object);

            // Add a ticket, remember it's id
            Guid addedTicketID=service.AddNewTicket("Ticket to delete", DateTime.Now.AddDays(1));
            
            //then delete the ticket
            service.DeleteTicket(addedTicketID);

            //after deletion, tickets list should be empty
            var sortedTickets = service.GetSortedTicketList();
            Assert.Empty(sortedTickets);
        }
    }
}
