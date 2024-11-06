internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        #region function trong List của Collection
        // khởi tạo danh sách
        // List<int> numbers = new List<int>();
        // // nhập n từ bàn phím với n là số lượng phần tử của mảng
        // string? n = Console.ReadLine();
        // int format = Convert.ToInt32(n);
        // for(int i = 0; i < format; i++){
        //     Console.WriteLine($"Mời bạn nhập số thứ {i + 1}");
        //     int number = Convert.ToInt32(Console.ReadLine());
        //     numbers.Add(number);
        // }

        // Console.WriteLine("Danh sách phần tử đã nhập là: ");
        // foreach(int number in numbers){
        //     Console.Write(number);
        //     Console.Write(",");
        // }
        // Console.WriteLine();
        // // C1: dùng Join(
        // Console.Write(String.Join(",", numbers));

        // // dùng function Sort để sắp xếp phần tử của mảng
        // numbers.Sort();
        // Console.WriteLine("Danh sách phần tử đã sắp xếp: ");
        // Console.Write(String.Join(",", numbers));

        // // dùng function Reverse()
        // numbers.Reverse();
        // Console.WriteLine();
        // Console.WriteLine("Danh sách phần tử đã sau khi dùng hàm Reverse: ");
        // Console.Write(String.Join(",", numbers));

        #endregion

        #region Bài 1: tính tổng các số lớn hơn 50 trong mảng
        // khai báo list phần tử
        List<int> numbers = new List<int> {20, 50, 31, 75, 20, 65, 20, 100};
        // kết quả của hàm tinhTongSoLon50 sẽ gán cho biến sum
        int sum = Bai1.tinhTongSoLon50(numbers);
        Console.WriteLine($"Tổng các số lớn hơn 50 của mảng là: {sum}");

        #endregion

        #region Bài 2: tìm số lớn nhất của mảng
        // giải thuật
        // B1: tìm 1 số bất kỳ trong mảng làm số lớn (số đầu tiên của mảng)
        // B2: duyệt mảng từ phần tử thứ 2 và so sánh với số đại diện
        // B3: nếu số đại diện nhỏ hơn phần tử đang xét => gán lại
        // B4: ngược lại => duyệt tiếp
        int max = Bai2.findMaxNumber(numbers);
        Console.WriteLine($"Số lớn nhất của mảng là: {max}");

        #endregion

        #region Bài 3: tìm tất cả những chuỗi bắt đầu bằng chữ m
        List<string> lstString = new List<string> {"banana", "mango", "Kiwi", "orange"};
        List<string> results = Bai3.findAllStartM(lstString);
        Console.WriteLine("Danh sách những phần tử bắt đầu bằng chữ m là: ");
        foreach(string result in results){
            Console.WriteLine(result);
        }
        
        #endregion

        #region Bài 4: liệt kê những phần tử không trùng nhau
        List<int> lstNumbers = new List<int> {1, 1, 1, 3, 3, 4, 5, 6, 6};
        List<int> lstResult = Bai4.unquieNumbers(lstNumbers);
        Console.WriteLine($"Danh sách các phần tử không trùng nhau là: ");
        foreach(int result in lstResult){
            Console.WriteLine(result);
        }
        #endregion

        #region Tìm hiểu về dictionary trong Collection
        Dictionary<string, string> dic = new Dictionary<string, string>();

        // thêm key-value vào dic
        dic.Add("Alice", "test");
        dic["Do"] = "Nam Trung";

        // duyệt dic
        foreach(KeyValuePair<string, string> pointer in dic){
            // pointer: key-value
            Console.WriteLine($"Họ: {pointer.Key}, Tên: {pointer.Value}");
        }

        // chỉ duyệt mỗi key hoặc value => y chang như bên List
        // chỉ duyệt key
        Console.WriteLine("danh sách các key là: ");
        foreach(string str in dic.Keys) {
            Console.WriteLine(str);
        }

        // C2:
        for(int i = 0; i < dic.Keys.Count; i++){
            Console.WriteLine(dic.Keys.ElementAt(i));
        }

        // update value cho dic
        dic["Alice"] = "Johnson";
        Console.WriteLine("Dic sau khi update:");
        foreach(KeyValuePair<string, string> pointer in dic) {
            Console.WriteLine($"Họ: {pointer.Key}, Tên: {pointer.Value}");
        }

        // xóa key-value trong dic
        dic.Remove("Alice");
        Console.WriteLine("Dic sau khi remove key-value:");
        foreach(KeyValuePair<string, string> pointer in dic) {
            Console.WriteLine($"Họ: {pointer.Key}, Tên: {pointer.Value}");
        }
        #endregion
    }
}