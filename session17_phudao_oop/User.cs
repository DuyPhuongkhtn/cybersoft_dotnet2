abstract class User {
    private string name;
    public string Name {
        get { return name; }
        set { name = value; }
    }

    private string email;
    public string Email {
        get { return email; }
        set { email = value; }
    }

    private string phoneNumber;
    public string PhoneNumber {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    public User(string name, string email, string phoneNumber) {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public virtual void viewBookingHistory() {
        Console.WriteLine($"User {Name}'s booking history: ");
    }
}