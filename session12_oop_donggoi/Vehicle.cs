class Vehicle {
    // thuộc tính (attribute)
    private string vehicleId;
    public string VehicleId {
        get { return vehicleId;}
        set { vehicleId = value; }
    }

    private string brand;
    public string  Brand {
        get { return brand;}
        set {brand = value;}
    }

    private int year;
    public int Year {
        get { return year;}
        set {
            if (value < 0) {
                throw new ArgumentException("Năm sản xuất không hợp lệ");
            }
            year = value;
        }
    }

    private double price;
    public double Price {
        get {return price;}
        set {
            if (value < 0) {
                throw new ArgumentException("Gía xe không hợp lệ");
            }
            price = value;
        }
    }

    // constructor
    public Vehicle(string vehicleId, string brand, int year, double price) {
        VehicleId = vehicleId;
        Brand = brand;
        Year = year;
        Price = price;
    }

    public virtual void displayInfo() {
        Console.WriteLine($" Mã phương tiện: {VehicleId}");
        Console.WriteLine($" Hãng: {Brand}");
        Console.WriteLine($" Năm sản xuất: {Year}");
        Console.WriteLine($" Giá: {Price}");
    }
}