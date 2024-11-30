class TruongNhom: NhanVien {

    public string MaQLNhom;

    public string getMaNV() {
        return this.MaNV;
    }

    public override double tinhLuong() {
        // double luongCoBan = base.tinhLuong(); // kế thừa lại phương thức tinhLuong() từ class cha
        return 500 + 1.5*500;
    }
}