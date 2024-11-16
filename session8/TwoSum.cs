class TwoSum {

    public static List<int> twoSum(List<int> lst, int target){
        for(int i = 0; i < lst.Count - 1; i++){
            for(int j = i + 1; j < lst.Count; j++) {
                if(lst[i] + lst[j] == target){
                    return new List<int>{i, j};
                }
            }
        }
        return null; // không tìm được 2 số thì trả về null
    }

    public static List<int> twoSumDictionary(List<int> lst, int target){
        // khai báo Dictionary để đánh dấu từng số trong danh sách lst
        // key - lưu giá trị từng phần tử của mảng
        // value - lưu chỉ số của phần tử tưởng ứng
        Dictionary<int, int> seenNumbers = new Dictionary<int, int>();
        for(int i = 0; i < lst.Count; i++){
            int completion = target - lst[i];
            if(seenNumbers.ContainsKey(completion)){
                return new List<int> {seenNumbers[completion], i};
            } else {
                // nếu completion ko nằm trong dic => add vào dic để đánh dấu
                seenNumbers.Add(lst[i], i);
            }
        }
        return null;
    }
}