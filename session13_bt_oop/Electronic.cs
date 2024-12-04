class Electronic: Product {
    private int warranty;
    public int Warranty {
        get { return warranty; }
        set {
            if (value < 0) {
                throw new ArgumentException("Warranty must be greater than 0");
            }
            warranty = value;
        }
    }

    public Electronic(
        int productId,
        string productName,
        double price,
        string description,
        int warranty
    ): base(productId, productName, price, description) {
        Warranty = warranty;
    }

    public override void displayInfo() {
        base.displayInfo();
        Console.WriteLine($"Warranty: {Warranty}");
    }
}