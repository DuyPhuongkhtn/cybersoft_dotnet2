class WordCount {
    public static void process() {
        Console.WriteLine("Mời bạn nhập đoạn văn: ");
        string text = Console.ReadLine();

        // B1: TÁCH TỪ
        string[] words = text.Split(new[]{' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);

        // B2: làm tương tự như session 8
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        foreach (string word in words) {
            // chuyển các từ về viết thường. VD: Many, many
            string lowerWord = word.ToLower();
            if(wordCounts.ContainsKey(lowerWord)) {
                wordCounts[lowerWord]++;
            } else {
                wordCounts[lowerWord] = 1;
            }
        }
        Console.WriteLine("Số lần xuất hiện từng từ là: ");
        foreach(KeyValuePair<string, int> pointer in wordCounts) {
            Console.WriteLine($"{pointer.Key}: {pointer.Value}");
        }
    }
}