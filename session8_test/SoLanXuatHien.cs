class SoLanXuatHien {
    public static Dictionary<string, int> CountOccurrences(List<string> items)
    {
        Dictionary<string, int> counts = new Dictionary<string, int>();
        foreach (string item in items)
        {
            if (counts.ContainsKey(item))
                counts[item]++;
            else
                counts[item] = 1;
        }
        return counts;
    }
}