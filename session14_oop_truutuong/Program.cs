internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        NhanVien nguyenVanA = new TruongPhong("NV001", "Nguyen Van A", 1000, 1.5);
        Console.WriteLine($"Luong cua Nguyen Van A: {nguyenVanA.tinhLuong()}");

        // Animal
        Animal dog = new Animal("Dog");
        dog.eat();
        dog.sleep();

        // Bài tập về quản lý khách sạn
        // abstract class: Room
        //  -roomId: string
        // - roomName: string
        // - basePrice: double

        // class con: 
        // - NormalRoom: Room
        // - LuxuryRoom: Room
        //      + extraService: string
        // - SuitedRoom: Room
        //      + extraService: string
        //      + premiumService: string

        // thêm interface
        // - IWifi: bool hasWifi()

        // class Hotel

        Room normalRoom = new NormalRoom("01", "Normal Room 1", 400000);
        Room luxuryRoom = new LuxuryRoom("02", "Luxury Room 1", 400000, "Fee breakfast");
        Room suiteRoom = new SuiteRoom("03", "Suite Room 1", 400000, "Fee breakfast", "Fee massage");

        Console.WriteLine($"Price of nornal room: {normalRoom.calculatePrice()}");
        Console.WriteLine($"Price of luxury room: {luxuryRoom.calculatePrice()}");
        Console.WriteLine($"Price of suite room: {suiteRoom.calculatePrice()}");
    }
}