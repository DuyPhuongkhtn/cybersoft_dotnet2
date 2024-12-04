class Fashion: Product {
    private string size;
    public string Size {
        get { return size; }
        set {
            List<string> validSizes = new List<string> {"S", "M", "L", "XL", "XXL"};
            if(string.IsNullOrWhiteSpace(value) || !validSizes.Contains(value)) {
                // !validSizes.Contains(value) => value không nằm trong validSizes
                throw new ArgumentException("Size must be S, M, L, XL, XXL");
            }
            size = value;
        }
    }

    public Fashion(
        int productId,
        string productName,
        double price,
        string description,
        string size
    ): base(productId, productName, price, description) {
        Size = size;
    }

    public override void displayInfo(){
        base.displayInfo();
        Console.WriteLine($"Size: {Size}");
    }
}