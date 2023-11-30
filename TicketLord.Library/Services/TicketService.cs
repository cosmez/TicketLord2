using System.Data.SQLite;
using Dapper;
using TicketLord.Library.Models;

namespace TicketLord.Library.Services;

public class TicketService 
{
    private readonly Settings _settings;

    public TicketService(Settings settings)
    {
        _settings = settings;
    }
    
    private async Task<SQLiteConnection> GetConnectionAsync()
    {
        var exists = File.Exists(_settings.SqliteFilename);
        var connection = new SQLiteConnection($"Data Source={_settings.SqliteFilename};");

        if (!exists)
        {
            await connection.ExecuteAsync(@"
                CREATE TABLE IF NOT EXISTS Tickets (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Descripcion TEXT NOT NULL,
                    Lugar INTEGER NOT NULL,
                    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
                );

                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 1', 1, '2022-01-01 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 2', 2, '2022-01-02 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 3', 3, '2022-01-03 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 4', 4, '2022-01-04 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 5', 5, '2022-01-05 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 6', 6, '2022-01-06 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 7', 7, '2022-01-07 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 8', 8, '2022-01-08 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 9', 9, '2022-01-09 10:00:00');
                INSERT INTO Tickets (Descripcion, Lugar, Timestamp) VALUES ('Description 10', 10, '2022-01-10 10:00:00');                
            ");
            
        }

        return connection;
    }
    
    
    public async Task<List<Ticket>> GetTicketsAsync()
    {
        var connection = await GetConnectionAsync();
        var tickets = await connection.QueryAsync<Ticket>(
            @"SELECT * FROM Tickets");
        return tickets.ToList();
    }
    
    
}