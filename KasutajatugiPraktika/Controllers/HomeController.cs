using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KasutajatugiPraktika.Models;
using KasutajatugiPraktika.Services;

namespace KasutajatugiPraktika.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TicketsService _ticketsService;

    public HomeController(ILogger<HomeController> logger, TicketsService ticketsService)
    {
        _logger = logger;
        _ticketsService = ticketsService;
    }

    //Displaying home page
    public IActionResult Index()
    {
        _logger.LogInformation("Fetching sorted tickets");
        List<Ticket> sortedTickets = _ticketsService.GetSortedTicketList();
        return View(sortedTickets);
    }
    
    //Displaying create ticket page
    public IActionResult Create()
    {
        return View();
    }

    //Displaying privacy page
    public IActionResult Privacy()
    {
        return View();
    }

    //handling errors
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    //Create ticket form submission handling
    [HttpPost]
    public IActionResult Create(string description, DateTime deadline)
    {
        _logger.LogInformation("Create Ticket with description " + description +" and deadline "+ deadline + " request received");
        _ticketsService.AddNewTicket(description,deadline);
        return RedirectToAction("Index");
    }
    
    //Marking ticket as solved
    public IActionResult Solve(Guid id)
    {
        _logger.LogInformation("Request to delete ticket with id: " + id + " received");
        _ticketsService.DeleteTicket(id);
        return RedirectToAction("Index");
    }
}