using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KasutajatugiPraktika.Models;
using KasutajatugiPraktika.Services;

namespace KasutajatugiPraktika.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Trying to sort tickets...");
        List<Ticket> sortedTickets = TicketsService.GetSortedTicketList();
        return View(sortedTickets);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpPost]
    public IActionResult Create(string description, DateTime deadline)
    {
        _logger.LogInformation("Create Ticket with description" + description +" and deadline "+ deadline + " request received");
        TicketsService.addNewTicket(description,deadline);
        return RedirectToAction("Index");
    }
    
    public IActionResult Solve(int id)
    {
        _logger.LogInformation("Request to delete ticket with id: " + id + " received");
        TicketsService.deleteTicket(id);
        return RedirectToAction("Index");
    }
}