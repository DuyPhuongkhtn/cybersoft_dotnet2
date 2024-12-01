class Motocycle: Vehicle {
    private string type;
    public string Type {
        get { return type; }
        set {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("Loại xe không hợp lệ");
            }
            type = value;
        }
    }

    private int power;
    public int Power {
        get { return power; }
        set {
            if (value < 0) {
                throw new ArgumentException("Cong suất không hợp lệ");
            }
            power = value;
        }
    }

    // constructor
    public Motocycle(
        string vehicleId,
        string brand,
        int year,
        double price,
        string type,
        int power
    ): base(vehicleId, brand, year, price) {
        Type = type;
        Power = power;
    }

    public override void displayInfo(){
        base.displayInfo();
        Console.WriteLine($"Loại xe: {Type}");
        Console.WriteLine($"Công suất: {Power}");
    }
}