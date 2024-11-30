class SinhVien: Nguoi {
    public string lop;
    public double diemTrungBinh;

    public SinhVien(
        string ID,
        string ten,
        string ngaySinh,
        string gioiTinh,
        string email,
        string lop,
        double diemTrungBinh
    ): base(ID, ten, ngaySinh, gioiTinh, email) {
        this.lop = lop;
        this.diemTrungBinh = diemTrungBinh;
    }

    public override void inThongTin()
    {
        base.inThongTin(); // dùng lại phương thức inThongTin của class cha
        Console.WriteLine($"Lớp: {lop}");
        Console.WriteLine($"Điểm trung bình: {diemTrungBinh}");
    }
}