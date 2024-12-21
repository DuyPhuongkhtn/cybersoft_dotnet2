class TicketManager {
    // ID: T1, T2, T3,....
    private List<Ticket> tickets = new List<Ticket>();
    private static int ticketCount = 1; // tạo ID cho ticket

    public Ticket createTicket(Movie movie, Customer customer, double price) {
        string ticketID = "T" + ticketCount;
        ticketCount++; // ticketCount = ticketCount + 1;

        Ticket ticket = new Ticket(ticketID, movie, customer, price);
        tickets.Add(ticket);
        return ticket;
    }

    public void displayTickets() {
        Console.WriteLine("Tickets: ");
        foreach(Ticket ticket in tickets) {
            ticket.displayTicket();
        }
    }
}