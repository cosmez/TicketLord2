namespace TicketLord.Library.Models;

public class Ticket
{
    public int Id { get; set; } //unique autoincrement
    public required string Descripcion { get; set; }
    public int Lugar { get; set; }
    public DateTime Timestamp { get; set; } //autoincrement defaults to current date
}