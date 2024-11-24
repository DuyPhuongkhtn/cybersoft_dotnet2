class NhanVien {
    public string MaNhanVien;
    public string TenNhanVien;
    public int tuoi;
    public string ngaySinh;
    public double luong;

    public virtual void TinhLuong() {
        // do something
        Console.WriteLine($"Luong cua nhan vien {TenNhanVien} la {luong}");
    }

}