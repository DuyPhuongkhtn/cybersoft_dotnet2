class TwoSum {
    public static int[] twoSum(List<int> nums, int target)
    {
        // Tạo một từ điển để lưu các số đã duyệt qua và chỉ số của chúng
        Dictionary<int, int> seenNumbers = new Dictionary<int, int>();

        // Duyệt qua từng phần tử trong danh sách nums
        for (int i = 0; i < nums.Count; i++)
        {
            // Tính phần còn lại cần để có tổng bằng target
            int neededNumber = target - nums[i];

            // Kiểm tra xem neededNumber có trong từ điển không
            if (seenNumbers.ContainsKey(neededNumber))
            {
                // Nếu có, trả về chỉ số của cặp số đã tìm được
                return new int[] { seenNumbers[neededNumber], i };
            }
            // Nếu chưa tìm thấy, thêm số hiện tại và chỉ số của nó vào từ điển
            seenNumbers[nums[i]] = i;
        }
        
        // Nếu không tìm thấy cặp số nào phù hợp, trả về null
        return null;
    }
}