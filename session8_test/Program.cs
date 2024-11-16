internal class Program
{
    private static void Main(string[] args)
    {
        #region two sum
        // Danh sách các số nguyên
        // List<int> nums = new List<int> { 2, 7, 11, 15 };
        
        // // Giá trị cần tìm
        // int target = 10;
        
        // // Gọi hàm TwoSum và lưu kết quả vào result
        // int[] result = TwoSum.twoSum(nums, target);
        
        // // In kết quả
        // if (result != null)
        // {
        //     Console.WriteLine($"Output: [{result[0]}, {result[1]}]");
        // }
        // else
        // {
        //     Console.WriteLine("Không tìm thấy cặp nào có tổng bằng target.");
        // }
        #endregion
        int a = 10;
        int b = a;
        a = 20;
        Console.WriteLine($"a = {a}, b = {b}");

        #region đếm số lần xuất hiện các phần tử trong list
        List<string> items = new List<string> { "apple", "banana", "apple", "orange", "banana", "apple" };
        Dictionary<string, int> result = SoLanXuatHien.CountOccurrences(items);

        foreach (KeyValuePair<string, int> kvp in result)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        #endregion
    }
}