using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketLord.Library.Models;
using TicketLord.Library.Services;

namespace TicketLord.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly TicketService _ticketService;
    
    public List<Ticket>? Tickets { get; set; }
 

    public IndexModel(ILogger<IndexModel> logger, TicketService ticketService)
    {
        _logger = logger;
        _ticketService = ticketService;
    }

    public async Task OnGetAsync()
    {
        Tickets = await _ticketService.GetTicketsAsync(); 
    }

    
}