class TruongNhom: NhanVien {
    public string nhomQuanLy;

    public override void TinhLuong() {
        // do something
        base.TinhLuong();
        Console.WriteLine($"Luong cua truong nhom {TenNhanVien} la {luong}");
    }
}