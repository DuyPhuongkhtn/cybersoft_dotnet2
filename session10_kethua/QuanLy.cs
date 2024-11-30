class QuanLy: TruongNhom {
    public string ThuKy;

    public override double tinhLuong(){
        double luongCoBan = base.tinhLuong();
        return luongCoBan + 500;
    }
}