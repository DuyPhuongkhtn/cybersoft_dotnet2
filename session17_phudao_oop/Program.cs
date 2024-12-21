internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Cinema cinema = new Cinema();

        // tạo data sẵn cho movie và customer
        Movie movie1 = new Movie("M1", "The Avengers", "Joss Whedon", 143, 8);
        Movie movie2 = new Movie("M2", "The batman", "Matt Reeves", 176, 9);
        cinema.addMovie(movie1);
        cinema.addMovie(movie2);

        // main menu
        int choice;
        bool isRunning = true;
        while(isRunning) {
            Console.WriteLine("===== MAIN MENU =====");
            Console.WriteLine("1. Add a new customer");
            Console.WriteLine("2. Book a ticket");
            Console.WriteLine("3. View user's tickets");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice) {
                case 1:
                    Console.WriteLine("Enter customer name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter customer email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter customer phone: ");
                    string phone = Console.ReadLine();

                    Customer customer = new Customer(name, email, phone);
                    cinema.addCustomer(customer);
                    break;
                case 2:
                    Console.WriteLine("Enter customer email:");
                    string email2 = Console.ReadLine();
                    Customer customer1 = cinema.Customers.Find(c => c.Email == email2);
                    if(customer1 == null) {
                        Console.WriteLine("Customer not found!");
                        break;
                    }

                    Console.WriteLine("Enter movie ID: ");
                    string movieId = Console.ReadLine();
                    Movie movie = cinema.Movies.Find(m => m.MovieID == movieId);
                    if(movie == null) {
                        Console.WriteLine("Movie not found!");
                        break;
                    }

                    Console.WriteLine("Enter price: ");
                    double price = Convert.ToDouble(Console.ReadLine());

                    cinema.bookTicket(movie, customer1, price);
                    break;
                case 3:
                    foreach(Customer c in cinema.Customers) {
                        c.viewBookingHistory();
                        Console.WriteLine("===========");
                    }
                    break;
                case 4:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}