internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<int> lst = new List<int>{2, 7, 9, 11, 15};
        //                            0  1  2   3   4
        int target = 26;
        Console.WriteLine("Bài 1: Tìm 2 số để tổng 2 số bằng với target");
        if(TwoSum.twoSum(lst, target) == null) {
            Console.WriteLine("Không có hai số nào có tổng bằng target");
        } else {
            List<int> indexes = TwoSum.twoSum(lst, target);
            Console.WriteLine($"Chỉ số 2 số có tổng bằng target là: {string.Join(',', indexes)}");
        }
        Console.WriteLine("Cách 2: Dùng dictionary");
        if(TwoSum.twoSumDictionary(lst, target) == null) {
            Console.WriteLine("Không có hai số nào có tổng bằng target");
        } else {
            List<int> indexes1 = TwoSum.twoSumDictionary(lst, target);
            Console.WriteLine($"Chỉ số 2 số có tổng bằng target là: {string.Join(',', indexes1)}");
        }

        #region Khái niệm về cách lưu trữ biến trong máy tính
        int number1 = 10;
        int number2 = number1;
        number1 = 30;
        Console.WriteLine($"number1={number1}, number2={number2}");
        #endregion
    }
}