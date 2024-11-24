internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        NhanVien nhanVien = new NhanVien();
        nhanVien.TenNhanVien = "NV001";
        Console.WriteLine(nhanVien.TenNhanVien);
        nhanVien.luong = 1000;
        nhanVien.TinhLuong();

        TruongNhom truongNhom = new TruongNhom();
        truongNhom.TenNhanVien = "TN001";
        truongNhom.luong = 2000;
        Console.WriteLine(truongNhom.TenNhanVien);
        truongNhom.TinhLuong();
    }
}