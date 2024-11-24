class HocSinh {
    public string hoTen;
    public string gioiTinh;
    public string email;
    public int tuoi;

    public void nhapThongTin() {
        Console.WriteLine("Mời bạn nhập thông tin học sinh: ");
        Console.WriteLine("Nhập họ tên: ");
        hoTen = Console.ReadLine();
        Console.WriteLine("Nhập giới tính: ");
        gioiTinh = Console.ReadLine();
        Console.WriteLine("Nhập email: ");
        email = Console.ReadLine();
        Console.WriteLine("Nhập tuổi: ");
        tuoi = Convert.ToInt32(Console.ReadLine());
    }

    public void xuatThongTin() {
        Console.WriteLine("Thông tin học sinh: ");
        Console.WriteLine($"Giới tính: {gioiTinh}");
        Console.WriteLine($"Tuoi: {tuoi}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Họ tên: {hoTen}");
    }
}