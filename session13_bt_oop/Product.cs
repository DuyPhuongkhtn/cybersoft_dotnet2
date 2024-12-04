class Product{
    private int productId;
    // integer: AUTO_INCREMENT
    // string (uuid): 43789e2a-7dce-49ed-8e64-ce89b9cb8620
    public int ProductId {
        get { return productId; }
        set {
            if (value < 0) {
                throw new ArgumentException("ID must be greater than 0");
            }
            productId = value;
        }
    }

    // exception
    // 5 loại lỗi phổ biến
    // 1. lỗi logic và tham số (ArgumentException, ...)
    // 2. Lỗi dữ liệu (FormatException, ...)
    // 3. Lỗi hệ thống
    // 4. Lỗi I/O và mạng
    // 5. Lỗi luồng và đa nhiệm

    private string productName;
    public string ProductName {
        get { return productName; }
        set {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("Product name must not be empty");
            }
            productName = value;
        }
    }

    private double price;
    public double Price {
        get { return price; }
        set {
            if (value < 0) {
                throw new ArgumentException("Price must be greater than 0");
            }
            price = value;
        }
    }

    private string description;
    public string Description {
        get { return description; }
        set {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("Description must not be empty");
            }
            description = value;
        }
    }

    public Product(int productId, string productName, double price, string description) {
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Description = description;
    }

    // static method
    // - function này không dùng tới các thuộc tính của đối tượng
    // - function này không cần phải khởi tạo đối tượng
    //  VD: Product.sum(1, 2);
    // - Còn nếu không dùng static thì phải khởi tạo đối tượng.
    public static int sum(int num1, int num2) {
        return num1 + num2;
    }

    public virtual void displayInfo() {
        Console.WriteLine($"Product ID: {ProductId}");
        Console.WriteLine($"Product Name: {ProductName}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Description: {Description}");
    }
}