class TruongPhong: NhanVien {
    private double heSoLuong;
    public double HeSoLuong {
        get { return heSoLuong; }
        set { heSoLuong = value; }
    }

    public TruongPhong(
        string maNV,
        string hoTen,
        double luongCoBan,
        double heSoLuong
    ): base(maNV, hoTen, luongCoBan) {
        this.heSoLuong = heSoLuong;
    }

    public override double tinhLuong() {
        this.LuongCoBan = this.LuongCoBan * HeSoLuong;
        return this.LuongCoBan;
    }
}