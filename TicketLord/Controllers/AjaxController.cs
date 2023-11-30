using Microsoft.AspNetCore.Mvc;
using TicketLord.Library.Services;

namespace TicketLord.Controllers;

[Controller]
public class AjaxController : Controller
{
    private readonly TicketService _ticketService;

    public AjaxController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> Json1()
    {
        var tickets = await _ticketService.GetTicketsAsync();
        return Json(tickets);
    }
    
    public IActionResult Json2()
    {
        return Json("2");
    }
}