using Newtonsoft.Json;

class VehicleManager {
    private List<Vehicle> vehicles;
    public List<Vehicle> Vehicles {
        get { return vehicles; }
        set { vehicles = value;}
    }

    private string filePath = "vehicles.json";

    // viết hàm loadData để đọc dữ liệu từ file json
    // => dùng thư viện Newtonsoft.Json
    private void loadData() { // dùng trong constructor
        // kiểm tra file có tồn tại không
        if (File.Exists(filePath)) {
            // đọc dữ liệu từ file json
            string json = File.ReadAllText(filePath);

            // chuyển dữ liệu từ string json sang List<Vehicle>
            Vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json);
        } else {
            Vehicles = new List<Vehicle>();
        }
    }

    // constructor
    public VehicleManager() {
        loadData();
    }

    // viết hàm saveData để lưu dữ liệu vào file json
    private void saveDada() { // dùng trong hàm addVehicle và removeVehicle
        // chuyển dữ liệu từ List<Vehicle> sang string json
        // Formatting.Indented: để hiển thị dữ liệu json đẹp hơn
        string json = JsonConvert.SerializeObject(Vehicles, Formatting.Indented);

        //  lưu dữ liệu vào file json
        File.WriteAllText(filePath, json);
    }

    // viết hàm addVehicle để thêm phương tiện vào danh sách
    public void addVehicle(Vehicle vehicle) {
        // kiểm tra mã phương tiện đã tồn tại chưa
        // lambda expression
        Vehicle vehi = Vehicles.Find(v => v.VehicleId == vehicle.VehicleId);
        if (vehi != null) {
            throw new ArgumentException("Mã phương tiện đã tồn tại");
        }
        Vehicles.Add(vehicle);
        saveDada();
        Console.WriteLine("Thêm phương tiện thành công");
    }

    // viết hàm addCar để thêm xe vào danh sách
    public void addCar() {
        Console.WriteLine("Nhập mã phương tiện: ");
        string vehicleId = Console.ReadLine();

        Console.WriteLine("Nhap hãng: ");
        string brand = Console.ReadLine();

        Console.WriteLine("Nhap năm sản xuất: ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Nhap giá: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nhap dòng xe: ");
        string model = Console.ReadLine();

        Console.WriteLine("Nhap màu xe: ");
        string color = Console.ReadLine();

        Console.WriteLine("Nhap dung tích động cơ: ");
        int engine = Convert.ToInt32(Console.ReadLine());

        Car car = new Car(vehicleId, brand, year, price, model, color, engine);
        addVehicle(car);
    }

    //  viết hàm displayAllVehicle để hiển thị danh sách phương tiện
    public void displayAllVehicle() {
        Console.WriteLine("\n=== Danh sách phương tiện ===");
        foreach(Vehicle vehicle in Vehicles) {
            vehicle.displayInfo();
            Console.WriteLine("----------------------------");
        }
    }
}