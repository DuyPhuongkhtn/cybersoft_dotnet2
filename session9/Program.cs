internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // bản chất của OOP đó chính là gom nhóm các biến
        // các biến được gọi là các thuộc tính
        // chữ cái đầu tiên của class phải là in hoa
        BaiViet baiviet1 = new BaiViet(); // vùng nhớ: x123
        baiviet1.tieuDe = "Nhiệm vụ đặc biệt 100 ngày' của Binh đoàn Trường Sơn";
        baiviet1.hinhAnh = "hinh1.png";
        baiviet1.noiDung = "Cuộc gọi giao nhiệm vụ phụ trách xây dựng cho thượng tá Vũ Đình Dũng lúc 0h30 ngày 16/9, chỉ vài tiếng sau khi Lào Cai chốt vị trí tái thiết Làng Nủ.";
        // Console.WriteLine($"bài viết 1: {baiviet1.hinhAnh}, {baiviet1.noiDung}, {baiviet1.tieuDe}");
        baiviet1.xuatThongTin();

        Console.WriteLine("=======================================");

        BaiViet baiviet2 = new BaiViet();
        baiviet2.tieuDe = "Chủ tịch nước gặp lãnh đạo Trung Quốc, Mỹ khi dự hội nghị APEC";
        baiviet2.hinhAnh = "hinh2.png";
        baiviet2.noiDung = "Chủ tịch nước Lương Cường gặp Chủ tịch Trung Quốc, Tổng thống Mỹ cùng lãnh đạo các nền kinh tế bên lề Hội nghị Cấp cao APEC.";
        baiviet2.xuatThongTin();

        BaiViet baiviet3;
        baiviet3 = baiviet1;
        Console.WriteLine($"kiểm tra: {baiviet3 == baiviet1}");
        baiviet3.hinhAnh = "hinh3.png";
        Console.WriteLine(baiviet1.hinhAnh);

        BaiViet baiviet4 = new BaiViet(); // vùng nhớ mới: x234
        baiviet4.hinhAnh = baiviet1.hinhAnh;
        baiviet4.noiDung = baiviet1.noiDung;
        baiviet4.tieuDe = baiviet1.tieuDe;
        Console.WriteLine($"kiểm tra: {baiviet4 == baiviet1}");

        BaiViet baiviet5 = new BaiViet();
        Console.WriteLine($"Giá trị mặc định của thuộc tính noiDung là: {baiviet5.noiDung}");
        // default value của các biến có kiểu dữ liệu là string là null
        // của integer là số 0
        // của boolean là số 0 (0 và 1)

        // Bài tập nhập môn
        // tạo đối tượng học sinh(họ tên, tuổi, giới tính, email)
        // xuất thông tin học sinh
        HocSinh nguyenVanA = new HocSinh();
        // nguyenVanA.nhapThongTin();
        nguyenVanA.xuatThongTin();

        // bài tập về nhà luyện thêm
        // Bài 1: tạo đối tượng sản phẩm (mã sản phẩm, tên sản phẩm, giá bán, số lượng tồn kho)
        // nhập và xuất thông tin sản phẩm

        SanPham sanPham = new SanPham();
        sanPham.nhapThongTin();
        sanPham.xuatThongTin();

        // Bài 2:
        // Tạo lớp Rectangle (hình chữ nhật) với các thuộc tính:

        // length (chiều dài)
        // width (chiều rộng)
        // Và các phương thức:
        // nhập thông tin
        // Tính diện tích (area)
        // Tính chu vi (perimeter)

    }
}