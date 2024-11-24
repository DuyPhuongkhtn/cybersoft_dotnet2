class BaiViet {
    public string tieuDe;
    public string noiDung;
    public string hinhAnh;

    // default khi khởi tạo đối tượng thì C# sẽ gọi hàm khởi tạo (constructor) mặc định
    // hàm khởi tạo này sẽ tạo giá trị mặc định cho các thuộc tính
    // cú pháp: public <tên class>(){}
    public BaiViet() {
        Console.WriteLine("Đây là hàm khởi tạo");
    } // khởi tạo hàm constructor

    public BaiViet(string tieuDe, string noiDung, string hinhAnh) {
        this.tieuDe = tieuDe;
        this.noiDung = noiDung;
        this.hinhAnh = hinhAnh;
    }

    public BaiViet(BaiViet other) {
        this.tieuDe = other.tieuDe;
        this.noiDung = other.noiDung;
        this.hinhAnh = other.hinhAnh;
    }

    // có 2 loại hàm constructor: có tham số và không có tham số
    // Lưu ý: trong class có thể có nhiều constructor xuất hiện.

    public void xuatThongTin() {
        Console.WriteLine("Thông tin bài viết là:");
        Console.WriteLine($"Tiêu đề: {tieuDe}");
        Console.WriteLine($"Nội dung: {noiDung}");
        Console.WriteLine($"Hình ảnh: {hinhAnh}");
    }
}