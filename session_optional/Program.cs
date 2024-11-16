internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Bài 1: Từ điển Anh - Việt");
        TuDienAnhViet.process();
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Bài 2: Tần suất xuất hiện các từ trong đoạn văn");
        WordCount.process();
        // Bài 3: Quản lý danh sách học sinh. Tương tự như bài từ điển Anh - Việt
    }
}