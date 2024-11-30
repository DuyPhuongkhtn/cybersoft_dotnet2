class SanPham {
    public string maSanPham;
    public string tenSanPham;
    public double giaBan;
    public int soLuong;

    public void nhapThongTin() {
        Console.WriteLine("Nhập mã sản phẩm: ");
        maSanPham = Console.ReadLine();

        Console.WriteLine("Nhập tên sản phẩm:");
        tenSanPham = Console.ReadLine();

        Console.WriteLine("Nhập giá bán:");
        giaBan = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nhập số lượng:");
        soLuong = Convert.ToInt32(Console.ReadLine());
    }

    public void xuatThongTin() {
        Console.WriteLine($"Mã sản phẩm: {maSanPham}");
        Console.WriteLine($"Tên sản phẩm: {tenSanPham}");
        Console.WriteLine($"Giá bán: {giaBan}");
        Console.WriteLine($"Số lượng: {soLuong}");
    }
}